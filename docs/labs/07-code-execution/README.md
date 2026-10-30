# Tworzenie agentów AI w .NET

## Laboratorium 07 — Code Execution

### Co zrobić, gdy agent nie ma gotowego narzędzia do rozwiązania problemu?

---

**Marcin Sulecki**  
marcin.sulecki@pw.edu.pl

Na tym laboratorium zobaczymy **Code Execution**, czyli generowanie i wykonywanie kodu przez model.

### Cel laboratorium

Na [Laboratorium 04](../04-tool-calling/README.md) model korzystał z funkcji przygotowanych przez programistę.

Teraz sprawdzimy, jak agent może wygenerować kod Pythona, uruchomić go w kontenerze Docker
i wykorzystać wynik wykonania do odpowiedzi użytkownikowi.

### Scenariusz

Nadal wykorzystujemy inteligentne gniazdko **Shelly Plug S Gen3** z podłączoną lampką.

Użytkownik pyta:

> Ile kosztuje świecenie mojej lampki przez 500 godzin przy cenie 4,50 zł/kWh?

Agent potrafi odczytać moc lampki, ale nie ma narzędzia obliczającego koszt energii.

Do wykonania ćwiczeń nie jest wymagane fizyczne urządzenie Shelly — można korzystać z symulatora.

### Przykłady

Kod źródłowy znajduje się w osobnym repozytorium:

**[Shelly — od HTTP do agentów AI](https://github.com/sulmar/shelly)**

| Projekt | Temat | Opis |
|---|---|---|
| [00-Shelly.Simulator](https://github.com/sulmar/shelly/tree/main/00-Shelly.Simulator) | Symulator | Symuluje urządzenie Shelly i udostępnia jego API HTTP. |
| [06-Shelly.CodeExecution](https://github.com/sulmar/shelly/tree/main/06-Shelly.CodeExecution) | Code Execution | Generuje i wykonuje kod Pythona w kontenerze Docker. |

### Eksperymenty

| Eksperyment | Temat | Forma |
|---|---|---|
| EXP-01 | Code Execution — obliczenie kosztu energii | Demonstracja prowadzącego |

**[Instrukcje eksperymentów →](./experiments.md)**

### Przygotowanie środowiska

Do wykonania ćwiczeń potrzebne są:

- .NET SDK
- [Ollama](https://ollama.com/download) z modelem obsługującym Tool Calling (np. `qwen3:8b`)
- Docker — do uruchamiania wygenerowanego kodu
- repozytorium [Shelly](https://github.com/sulmar/shelly) i uruchomiony symulator

Model, repozytorium i symulator przygotuj zgodnie z
[Laboratorium 04 — Przygotowanie środowiska](../04-tool-calling/README.md#przygotowanie-środowiska).

Przykład `06-Shelly.CodeExecution` uruchamiaj zgodnie z instrukcją w jego katalogu.

### Najważniejsze pojęcia

| Pojęcie | Znaczenie |
|---|---|
| Code Execution | Wykonywanie kodu wygenerowanego przez model |

### Wykład

Teoria: [Wykład 06 — Code Execution](../../lectures/06-code-execution/README.md)
