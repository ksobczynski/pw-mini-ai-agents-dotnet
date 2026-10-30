# Tworzenie agentów AI w .NET

## Laboratorium 07 — Eksperymenty

### Code Execution

---

**Marcin Sulecki**  
marcin.sulecki@pw.edu.pl

Eksperymenty wykonujemy na przykładach z repozytorium [Shelly](https://github.com/sulmar/shelly).

Przed rozpoczęciem przygotuj środowisko zgodnie z [README.md](./README.md).

## Eksperymenty

| Eksperyment | Temat | Forma |
|---|---|---|
| EXP-01 | Code Execution — obliczenie kosztu energii | Demonstracja prowadzącego |

---

## EXP-01 — Code Execution (demonstracja)

**Cel:** poznanie mechanizmu generowania i wykonywania kodu przez agenta.

Uruchomimy aplikację `06-Shelly.CodeExecution`.

Użytkownik pyta:

> Ile kosztuje świecenie mojej lampki przez 500 godzin przy cenie 4,50 zł/kWh?

Agent może:

1. Odczytać aktualną moc lampki.
2. Wygenerować kod Pythona obliczający zużycie energii i koszt.
3. Uruchomić kod w kontenerze Docker.
4. Odczytać wynik wykonania.
5. Przedstawić odpowiedź użytkownikowi.

### Pytania do dyskusji

- Dlaczego model zdecydował się wygenerować kod?
- Czy te obliczenia można wykonać bez Pythona?
- Co się stanie, jeśli wygenerowany kod zawiera błąd?
- Czy model potrafi poprawić kod na podstawie komunikatu błędu?
- Jakie zagrożenia wiążą się z wykonywaniem kodu wygenerowanego przez LLM?

> **Wygenerowanie kodu nie oznacza jego wykonania, a poprawne wykonanie nie gwarantuje poprawności wyniku.**

---

## Podsumowanie

Po wykonaniu eksperymentu powinieneś rozumieć:

- jakie możliwości i zagrożenia wprowadza Code Execution.

Na kolejnym laboratorium: [Laboratorium 08 — Embeddings](../08-embeddings/readme.md).
