# Tworzenie agentów AI w .NET

## Laboratorium 10 — Architektura agentów AI

### Jak model może realizować cel wymagający kilku działań?

---

**Marcin Sulecki**  
marcin.sulecki@pw.edu.pl

Na tym laboratorium zobaczymy **agenta AI**, który samodzielnie dobiera działania w celu realizacji zadania użytkownika.

### Cel laboratorium

Na wcześniejszych laboratoriach poznaliśmy [Tool Calling](../04-tool-calling/README.md), [MCP](../05-mcp/README.md)
oraz [Code Execution](../07-code-execution/README.md).

Teraz sprawdzimy, jak agent obserwuje stan urządzenia, podejmuje decyzje, wykonuje działania
i weryfikuje ich rezultaty — oraz jak jego możliwości zależą od dostępnych narzędzi.

### Scenariusz

Nadal wykorzystujemy inteligentne gniazdko **Shelly Plug S Gen3** z podłączoną lampką.

Użytkownik określa cel:

> Upewnij się, że lampka jest włączona.

Agent decyduje, jakie działania wykonać, aby go osiągnąć.

Do wykonania ćwiczeń nie jest wymagane fizyczne urządzenie Shelly — można korzystać z symulatora.

### Przykłady

Kod źródłowy znajduje się w osobnym repozytorium:

**[Shelly — od HTTP do agentów AI](https://github.com/sulmar/shelly)**

| Projekt | Temat | Opis |
|---|---|---|
| [00-Shelly.Simulator](https://github.com/sulmar/shelly/tree/main/00-Shelly.Simulator) | Symulator | Symuluje urządzenie Shelly i udostępnia jego API HTTP. |
| [05-Shelly.Agent](https://github.com/sulmar/shelly/tree/main/05-Shelly.Agent) | Agent AI | Realizuje zadania wymagające obserwacji, działania i weryfikacji. |

### Eksperymenty

| Eksperyment | Temat | Forma |
|---|---|---|
| EXP-01 | Agent AI — włączenie lampki na określony czas | Zadanie problemowe i programistyczne |

**[Instrukcje eksperymentów →](./experiments.md)**

### Przygotowanie środowiska

Do wykonania ćwiczeń potrzebne są:

- .NET SDK
- [Ollama](https://ollama.com/download) z modelem obsługującym Tool Calling (np. `qwen3:8b`)
- repozytorium [Shelly](https://github.com/sulmar/shelly) i uruchomiony symulator

Model, repozytorium i symulator przygotuj zgodnie z
[Laboratorium 04 — Przygotowanie środowiska](../04-tool-calling/README.md#przygotowanie-środowiska).

Przykład `05-Shelly.Agent` uruchamiaj zgodnie z instrukcją w jego katalogu.

### Najważniejsze pojęcia

| Pojęcie | Znaczenie |
|---|---|
| Agent AI | System realizujący cele przez obserwację i podejmowanie działań |
