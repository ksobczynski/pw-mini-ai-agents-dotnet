# Raport — Laboratorium 03

**Zespół:**  Michał Mueller, Kazimierz Krześniak, Jakub Motyka
**Data:**  16.10-21.10

## Środowisko

| Parametr | Wartość |
|----------|---------|
| Wersja Ollama | Korzystaliśmy z zewnętrznego API PCSS|
| Sprzęt (CPU/GPU, RAM) | Nie dotyczy, korzystaliśmy z API |
| Liczba dostępnych notatek | 170 |

## EXP-00 — Sposób oceny wyników

Jak oceniamy poprawność odpowiedzi modelu? Jakie metryki przyjmujemy i dlaczego?

| Metryka | Definicja |
|---------|-----------|
| Floor accuracy | % poprawnie podanych ilość pięter |
| Elevator accuracy | % poprawnie  powiedział czy jest winda|
| Exact match | % poprawnie udało sie poprawnie oba powyższe|
| Średni czas [ms] | średni czas oczekiwania na odpowiedź w ms  |
| Poprawny JSON | to json o poprawnej strukturze oraz odpowiednimi nazwami pól |
| Powtarzalne notatki | powtarzalność takich samych wyników przy tych samych notatkach |


## EXP-01 — Porównanie modeli

| Model | Floor accuracy | Elevator accuracy | Exact match | Średni czas [ms] |
|---|---|---|---|---|
| Bielik 11B | 0.2 | 0.3 | 0.2 | 1998 |
| DeepSeek-V3.1 (1) | 1.0 | 0.8 | 0.8 | 953 |
| DeepSeek-V3.1 (2) | 1.0 | 0.8 | 0.8 | 683 |
| DeepSeek-V4-Flash | 0.7 | 0.7 | 0.6 | 213 |
| Qwen3.5-397B-A17B | 1.0 | 0.9 | 0.9 | 12734 |


**Exact match** oznacza odsetek notatek, dla których model poprawnie rozpoznał jednocześnie oba pola: `floor` i `elevator`.

**Wnioski:**
 Qwen3.5-397B-A17B poradził sobie najlepiej potrzebował jednak kilkukrotnie więcej czasu niewiele gorszy od niego DeepSeek-V3.1, który potrzebował 10x mniej czasu na odpowowiedz. Najwiekszą prędkością wykazał się model DeepSeek-V4-Flash, dając jednak zauważalnie gorsze wyniki. Z drugiej strony Bielik 11B chociaż zdecydowanie najtańszy okazał się wolny i absolutnie nieskuteczny.

## EXP-02 — Prompting

| Model | Wariant | Floor accuracy | Elevator accuracy | Exact match | Średni czas [ms] |
|---|---|---|---|---|---|
| DeepSeek-V4-Flash | zero-shot | 0.73 | 0.70 | 0.57 | 247 |
| DeepSeek-V4-Flash | one-shot | 0.90 | 0.80 | 0.75 | 199 |
| DeepSeek-V4-Flash | few-shot | 0.95 | 0.80 | 0.75 | 176 |

**Wnioski:**
Dla DeepSeek-V4-Flash dodanie przykładów nie tylko znacznie zwiększyło procent poprawnych odpowiedzi ale też  zauważalnie skróciło czas generowania odpowiedzi. Różnicą pomiędzy one-shot i few-shot nie jest znacząca w poprawności ale nadal poprawiło czas odpowiedzi.

## EXP-03 — Temperature

DeepSeek-V4-Flash
| Temperature | Exact match | Powtarzalne notatki |
|---|---|---|
| 0.0 | 0.62 |  (0.62 / 0.62), valid JSON: 46/50 |
| 0.5 | 0.67 |  (0.68 i 0.66), najwyższy wynik, valid JSON: 45–49/50 |
| 1.0 | 0.61 |  (0.56 i 0.66), wysoka wariancja, valid JSON: 43–50/50 |

**Wnioski:**
Najlepsze wyniki dała temperatura 0.5 osiągając nieduże różnice w skuteczności a wyraźnie wyższy procent poprawności JSON. Przy temperaturze 0.0 wyniki, które były najbardziej powtarzalne w swojej skuteczności. Przy temperaturze 1 osiągaliśmy zarówno najlepsze i najgorsze wyniki więc to podejście, o ile może dać bardzo dobry rezultat to jego wynik będzie mniej powtarzalny.

## EXP-04 — Structured output — JSON i walidacja

| Wariant | Poprawny JSON | Exact match |
|---|---|---|
| prompt | 9/10 | 0.7 |
| json-schema | 10/10  | 0.7 |

**Wnioski:**
Korzystając z sprecyzowania json w prompcie skuteczność była przyzwoita ale dzięki skorzystaniu z json-schema osiągneliśmy skuteczność 100% co wyeliminowało błedy formatowania

## Najtrudniejsze notatki
```NOTE-007 "4 piętro, winda tylko do 3" => floor=4, elevator=false```. Nigdy nie dostaliśmy ```elevator=true```.


## Rekomendacja

Do projektu wybieramy DeepSeek-V3.1.
