# Tworzenie agentów AI w .NET

## Laboratorium 03 — Eksperymenty

### Modele i prompting

---

**Marcin Sulecki**  
marcin.sulecki@pw.edu.pl

Eksperymenty wykonujemy na notatkach kierowców z katalogu `data/`.

Przed rozpoczęciem przygotuj środowisko zgodnie z [readme.md](./readme.md).

## Eksperymenty

| Eksperyment | Cel |
|-------------|-----|
| EXP-00 | Zaprojektowanie sposobu oceny wyników |
| EXP-01 | Porównanie dwóch modeli |
| EXP-02 | Porównanie zero-shot, one-shot i few-shot |
| EXP-03 | Zbadanie wpływu temperature |
| EXP-04 | Structured output — JSON i walidacja |

Wyniki są dopisywane do `results/results.csv`, a raport przygotuj na podstawie `reports/template.md`.

---

## EXP-00 — Jak oceniać wyniki?

EXP-00 jest kluczowy: zanim zaczniemy optymalizować rozwiązanie, musimy ustalić, po czym poznamy, że jest lepsze.

| Metryka | Znaczenie |
|---------|-----------|
| Floor accuracy | Odsetek poprawnie rozpoznanych pięter |
| Elevator accuracy | Odsetek poprawnie rozpoznanych informacji o windzie |
| Exact match | Odsetek notatek, dla których oba pola są poprawne |

Dzięki temu można odkryć, że model świetnie rozpoznaje piętra, ale ma problemy z interpretacją informacji o windzie.

---

## EXP-01 — Porównanie modeli

**Cel:** sprawdzenie, jak wybór modelu wpływa na jakość i czas odpowiedzi.

Kod: `src/Experiments/EXP-01-model-comparison/`

```bash
dotnet run --project src/ModelLab -- EXP-01
dotnet run --project src/ModelLab -- EXP-01 --model gemma3:4b,qwen2.5-coder
```

Bez `--model` porównywane są `gemma3:4b` i `qwen3:4b`. Wszystkie modele otrzymują ten sam prompt (zero-shot) i ten sam zbiór notatek.

**Pytanie:** czy większy lub nowszy model zawsze daje lepsze wyniki? Ile kosztuje nas to w czasie odpowiedzi?

---

## EXP-02 — Prompting

**Cel:** porównanie wariantów zero-shot, one-shot i few-shot.

Kod: `src/Experiments/EXP-02-prompting/`

### Zadanie

Uzupełnij brakujący wariant **one-shot** (jeden przykład z `data/prompt-examples.csv`) — w kodzie oznaczony jako `TODO`.

```bash
dotnet run --project src/ModelLab -- EXP-02
```

**Pytanie:** które notatki zaczęły być rozpoznawane poprawnie dopiero po dodaniu przykładów?

---

## EXP-03 — Temperature

**Cel:** zbadanie wpływu temperatury na poprawność i powtarzalność odpowiedzi.

Kod: `src/Experiments/EXP-03-temperature/`

```bash
dotnet run --project src/ModelLab -- EXP-03
```

Ten sam model i prompt — zmieniamy tylko temperaturę (`0.0`, `0.5`, `1.0`). Każda notatka jest przetwarzana kilkukrotnie, a program zlicza, ile różnych odpowiedzi zwrócił model.

**Pytanie:** jaką temperaturę wybrać dla agenta, który ekstrahuje dane, a jaką dla agenta, który generuje treści?

---

## EXP-04 — Structured output — JSON i walidacja

**Cel:** sprawdzenie, czy model zwraca poprawny JSON, który aplikacja może przetworzyć programowo.

Kod: `src/Experiments/EXP-04-structured-output/`

```bash
dotnet run --project src/ModelLab -- EXP-04
```

Porównujemy dwa warianty:

- `prompt` — format JSON opisany tylko w prompcie,
- `json-schema` — natywny tryb JSON Schema w Ollama.

**Pytanie:** czy poprawny składniowo JSON oznacza poprawną odpowiedź?

---

## Podsumowanie

Po wykonaniu eksperymentów powinieneś rozumieć:

- jak mierzyć jakość odpowiedzi modelu,
- jak wybór modelu, promptu i temperatury wpływa na wyniki,
- dlaczego agent potrzebuje odpowiedzi w ustrukturyzowanym formacie.

Na kolejnym laboratorium: [Laboratorium 04 — Tool Calling](../04-tool-calling/README.md).
