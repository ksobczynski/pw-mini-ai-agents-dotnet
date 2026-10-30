# Tworzenie agentów AI w .NET

## Laboratorium 04 — Tool Calling

### Jak sprawić, żeby model językowy nie tylko odpowiadał, ale również wykonywał działania?

---

**Marcin Sulecki**  
marcin.sulecki@pw.edu.pl

Na tym laboratorium poznamy:

1. **HTTP API** — jak aplikacja komunikuje się z urządzeniem?
2. **Tool Calling** — jak model wybiera funkcje i przekazuje ich argumenty?

Na kolejnych laboratoriach wykorzystamy te same przykłady do poznania
[MCP](../05-mcp/README.md),
[Code Execution](../07-code-execution/README.md) oraz
[architektury agentów AI](../10-agent-architecture/README.md).

### Scenariusz

Wykorzystamy inteligentne gniazdko **Shelly Plug S Gen3** z podłączoną lampką.

Zaczniemy od bezpośredniego sterowania urządzeniem przez HTTP API, a następnie udostępnimy te same operacje modelowi językowemu.

Użytkownik będzie mógł wydawać polecenia w języku naturalnym:

> Włącz lampkę.

> Czy lampka jest teraz włączona?

Zobaczymy, jak model wybiera narzędzia i korzysta z ich wyników.

Do wykonania ćwiczeń nie jest wymagane fizyczne urządzenie Shelly — można korzystać z symulatora.

### Dla zainteresowanych

W przykładach wykorzystujemy inteligentne gniazdko **Shelly Plug S Gen3**.

Dokumentacja API:

- [Shelly Plug S Gen3 — dokumentacja urządzenia](https://shelly-api-docs.shelly.cloud/gen2/Devices/Gen3/ShellyPlugSG3)
- [Switch — dokumentacja API](https://shelly-api-docs.shelly.cloud/gen2/ComponentsAndServices/Switch)

W przykładach korzystamy z dwóch metod:

- `Switch.Set` — włączanie i wyłączanie gniazdka.
- `Switch.GetStatus` — odczyt stanu gniazdka i aktualnego poboru mocy.

Shelly udostępnia lokalne API HTTP, dzięki któremu można
komunikować się z urządzeniem bez korzystania z chmury producenta.


### Przykłady

Kod źródłowy znajduje się w osobnym repozytorium:

**[Shelly — od HTTP do agentów AI](https://github.com/sulmar/shelly)**

| Projekt | Temat | Opis |
|---|---|---|
| [00-Shelly.Simulator](https://github.com/sulmar/shelly/tree/main/00-Shelly.Simulator) | Symulator | Symuluje urządzenie Shelly i udostępnia jego API HTTP. |
| [01-Shelly.Http](https://github.com/sulmar/shelly/tree/main/01-Shelly.Http) | HTTP API | Bezpośrednie sterowanie urządzeniem z aplikacji .NET. |
| [02-Shelly.ToolCalling](https://github.com/sulmar/shelly/tree/main/02-Shelly.ToolCalling) | Tool Calling | Model wybiera i wywołuje funkcje sterujące urządzeniem. |

### Eksperymenty

| Eksperyment | Temat | Forma |
|---|---|---|
| EXP-00 | HTTP API | Ćwiczenie |
| EXP-01 | Tool Calling — odczyt stanu lampki | Zadanie programistyczne |
| EXP-02 | Dla chętnych — `Switch.Toggle` | Zadanie programistyczne |

**[Instrukcje eksperymentów →](./experiments.md)**

### Przygotowanie środowiska

Do wykonania ćwiczeń potrzebne są:

- .NET SDK
- [Ollama](https://ollama.com/download)

#### 1. Pobierz model

```bash
ollama pull qwen3:8b
```

Możesz również wykorzystać inny model obsługujący Tool Calling, dostosowany do możliwości swojego komputera.

#### 2. Pobierz repozytorium

```bash
git clone https://github.com/sulmar/shelly.git
cd shelly
```

#### 3. Uruchom symulator

```bash
dotnet run --project 00-Shelly.Simulator
```

Symulator udostępnia API pod adresem:

`http://localhost:8080`

#### 4. Sprawdź komunikację

W drugim terminalu:

```bash
curl -s "http://localhost:8080/rpc/Switch.Set?id=0&on=true"
curl -s "http://localhost:8080/rpc/Switch.GetStatus?id=0"
curl -s "http://localhost:8080/rpc/Switch.Set?id=0&on=false"
```

#### 5. Uruchom przykład Tool Calling

```bash
dotnet run --project 02-Shelly.ToolCalling -- http://localhost:8080
```

> **Uwaga:** jeśli chcesz pracować z fizycznym urządzeniem, zamiast `localhost:8080` musisz przekazać adres IP swojego Shelly.

Pozostałe przykłady uruchamiaj zgodnie z instrukcjami w ich katalogach.

### Najważniejsze pojęcia

| Pojęcie | Znaczenie |
|---|---|
| Tool | Funkcja udostępniona modelowi przez aplikację |
| Tool Calling | Mechanizm, w którym model zgłasza żądanie wywołania funkcji |
| Tool Result | Wynik wykonania narzędzia przekazywany do modelu |

> **Model wybiera narzędzie, ale to aplikacja odpowiada za jego wykonanie.**

### Wykład

Teoria: [Wykład 03 — Tool Calling i MCP](../../lectures/03-tool-calling/README.md)
