# Raport — Laboratorium 03

**Zespół:** Coffer
**Data:** 2026-10-22

## Środowisko

| Parametr | Wartość |
|----------|---------|
| Wersja Ollama | 0.40.5 |
| Sprzęt (CPU/GPU, RAM) | Apple M3 Pro, 18 GB pamięci zunifikowanej (CPU i GPU współdzielą pamięć) |
| Liczba dostępnych notatek | 170 |

## EXP-00 — Sposób oceny wyników

Każdą odpowiedź modelu porównujemy z ręcznie opisaną wartością oczekiwaną. Oceniamy osobno każde pole oraz całą odpowiedź naraz, ponieważ w projekcie użyteczna jest tylko notatka z poprawnie rozpoznanym zarówno piętrem, jak i windą.

| Metryka | Definicja |
|---------|-----------|
| Floor accuracy | Odsetek notatek, w których pole `floor` jest zgodne z wartością oczekiwaną |
| Elevator accuracy | Odsetek notatek, w których pole `elevator` jest zgodne z wartością oczekiwaną |
| Exact match | Odsetek notatek, w których **oba** pola (`floor` i `elevator`) są poprawne jednocześnie. To metryka główna, bo tylko taki wynik nadaje się do dalszego przetwarzania |
| Średni czas [ms] | Średni czas odpowiedzi modelu na jedną notatkę. Ma znaczenie, bo system ma działać na bieżąco |
| Poprawny JSON | Odsetek odpowiedzi, które dają się sparsować do oczekiwanej struktury |
| Powtarzalne notatki | Odsetek notatek, dla których kilka uruchomień z tym samym ustawieniem dało identyczną odpowiedź. Mierzy stabilność modelu |

## EXP-01 — Porównanie modeli

| Model | Floor accuracy | Elevator accuracy | Exact match | Średni czas [ms] |
|-------|----------------|-------------------|-------------|------------------|
| gemma3:4b | 80% | 40% | 40% | 1080 |
| mistral:7b | 70% | 60% | 40% | 966 |
| deepseek-r1:14b | 90% | 90% | 80% | 23245 |

**Exact match** oznacza odsetek notatek, dla których model poprawnie rozpoznał jednocześnie oba pola: `floor` i `elevator`.

**Wnioski:** Najlepsze wyniki osiąga deepseek-r1:14b (80% exact match), ale odpowiada około 24 razy wolniej niż pozostałe modele (ponad 23 s na notatkę). Jest to model „rozumujący”, który przed odpowiedzią generuje długi tok myślenia, co tłumaczy ten czas. Mistral i gemma mają taki sam exact match (40%), jednak mistral jest szybszy i lepiej rozpoznaje windę (60% wobec 40%). Ponieważ elevator accuracy było najsłabszym punktem mniejszych modeli, do dalszych eksperymentów wybraliśmy mistral:7b.

## EXP-02 — Prompting

| Wariant | Floor accuracy | Elevator accuracy | Exact match |
|---------|----------------|-------------------|-------------|
| zero-shot | 70% | 60% | 40% |
| one-shot | 50% | 60% | 40% |
| few-shot | 80% | 80% | 60% |

**Wnioski:** Few-shot daje wyraźnie najlepsze wyniki: exact match wzrasta z 40% do 60%, a elevator accuracy z 60% do 80%. One-shot nie pomógł, a nawet pogorszył rozpoznawanie piętra (50%). Prawdopodobnie model zbyt mocno dopasowywał się do jednego przykładu i kopiował jego format lub wartości. Kilka zróżnicowanych przykładów pokazuje modelowi więcej sposobów zapisu piętra i windy, dzięki czemu lepiej uogólnia.

## EXP-03 — Temperature

| Temperature | Exact match | Powtarzalne notatki |
|-------------|-------------|---------------------|
| 0.0 | 40% | 100% |
| 0.5 | 36% | 90% |
| 1.0 | 46% | 70% |

**Wnioski:** Przy temperaturze 0.0 model jest w pełni powtarzalny (100%). Wraz ze wzrostem temperatury stabilność spada do 70% przy 1.0. Wyższy exact match przy 1.0 (46%) nie oznacza, że model działa lepiej: różnica kilku punktów procentowych przy tak małej próbie mieści się w granicach losowości, a model przestaje być przewidywalny (ta sama notatka może raz dać dobrą, a raz złą odpowiedź). W zadaniu ekstrakcji danych zależy nam na deterministycznym wyniku, dlatego wybieramy temperaturę 0.0.

## EXP-04 — Structured output — JSON i walidacja

| Wariant | Poprawny JSON | Exact match |
|---------|---------------|-------------|
| prompt | 100% | 40% |
| json-schema | 100% | 40% |

**Wnioski:** Oba warianty dały w 100% poprawny JSON i taki sam exact match (40%). Wymuszenie formatu przez JSON Schema nie poprawia więc trafności, a jedynie gwarantuje strukturę odpowiedzi. Mimo to wybieramy json-schema, ponieważ format jest wtedy zapewniony przez serwer, a nie zależy od tego, czy model „posłucha” promptu. Przy większej liczbie notatek lub innym modelu wariant „prompt” może zacząć zwracać niepoprawny JSON. Exact match na poziomie 40% (taki sam jak w zero-shot) pokazuje, że ograniczeniem jest treść promptu, a nie format odpowiedzi.

## Najtrudniejsze notatki

We wszystkich modelach i wariantach elevator accuracy było niższe lub równe floor accuracy, więc rozpoznanie windy okazało się trudniejsze niż rozpoznanie piętra.

Najczęstsze błędy:
- [ID notatki] — [co model zwrócił, a co było oczekiwane]
- [ID notatki] — [...]

Prawdopodobne przyczyny (do potwierdzenia na powyższych przykładach):
- notatka wspomina więcej niż jedną windę lub piętro (np. „przesiadka z windy A na B”), a model wybiera niewłaściwą wartość,
- piętro zapisane słownie lub nietypowo („parter”, „-1”, „drugie piętro”, „poziom 0”),
- potoczne lub skrócone nazwy wind, których model nie łączy z oczekiwaną wartością,
- brak jednej z informacji w notatce, gdy model zamiast zwrócić wartość pustą zgaduje.

## Wniosek

**Model:** mistral:7b
**Prompt:** few-shot
**Temperature:** 0.0
**Format odpowiedzi:** JSON Schema

Dowody:
- **Trafność:** few-shot podniósł exact match mistrala z 40% do 60% oraz elevator accuracy z 60% do 80% (EXP-02).
- **Szybkość:** mistral odpowiada w około 1 s na notatkę (966 ms), czyli ponad 20 razy szybciej niż deepseek-r1:14b (EXP-01). Przy 170 notatkach to około 3 minuty zamiast ponad godziny.
- **Powtarzalność:** przy temperaturze 0.0 wyniki są w 100% powtarzalne (EXP-03), więc system zachowuje się przewidywalnie.
- **Niezawodność formatu:** JSON Schema gwarantuje poprawną strukturę odpowiedzi (EXP-04).

Świadomie rezygnujemy z deepseek-r1:14b, który osiąga wyższy exact match (80%), ale jego czas odpowiedzi (ponad 23 s) jest nieakceptowalny w projekcie.

Ograniczenia i dalsze kroki:
- eksperymenty prowadziliśmy na małej próbce, więc różnice rzędu 10 punktów procentowych mogą wynikać z losowości. Rekomendowaną konfigurację należy sprawdzić na wszystkich 170 notatkach,
- połączenia few-shot + temperature 0.0 + JSON Schema nie testowaliśmy jako całości, a to ono powinno zostać zmierzone jako konfiguracja docelowa,
- przykłady w few-shot warto dobrać pod najtrudniejsze przypadki (kilka wind w jednej notatce, nietypowy zapis piętra).