# Tworzenie agentów AI w .NET

## Laboratorium 04 — Eksperymenty

### Tool Calling

---

**Marcin Sulecki**  
marcin.sulecki@pw.edu.pl

Eksperymenty wykonujemy na przykładach z repozytorium [Shelly](https://github.com/sulmar/shelly).

Przed rozpoczęciem przygotuj środowisko zgodnie z [README.md](./README.md).

## Eksperymenty

| Eksperyment | Temat | Forma |
|---|---|---|
| EXP-00 | HTTP API | Ćwiczenie |
| EXP-01 | Tool Calling — odczyt stanu lampki | Zadanie programistyczne |
| EXP-02 | Dla chętnych — `Switch.Toggle` | Zadanie programistyczne |

---

## EXP-00 — HTTP API

**Cel:** poznanie komunikacji z urządzeniem bez udziału modelu językowego.

Uruchom symulator Shelly oraz aplikację `01-Shelly.Http`.

Sprawdź, w jaki sposób aplikacja wykorzystuje `HttpClient` do sterowania urządzeniem.

### Zadanie

Wykonaj następujące operacje:

1. Włącz lampkę.
2. Odczytaj jej stan.
3. Wyłącz lampkę.

**Pytanie:** co zmieni się w aplikacji, kiedy zamiast użytkownika wybierającego operację decyzję będzie podejmował model językowy?

---

## EXP-01 — Tool Calling

**Cel:** rozszerzenie możliwości modelu przez dodanie nowego narzędzia.

Uruchom aplikację `02-Shelly.ToolCalling`.

Sprawdź działanie poleceń:

> Włącz lampkę.

> Wyłącz lampkę.

### Zadanie

Rozszerz aplikację tak, aby model potrafił odpowiedzieć na pytania:

> Czy lampka jest teraz włączona?

> Ile watów pobiera aktualnie lampka?

**Wymagania:**

- Dodaj narzędzie odczytujące stan urządzenia.
- Udostępnij je modelowi przez Tool Calling.
- Sprawdź, czy model korzysta z narzędzia, gdy potrzebuje aktualnych danych.
- Zweryfikuj odpowiedź modelu na podstawie rzeczywistego stanu urządzenia.

**Pytanie:** dlaczego model nie powinien odpowiadać na pytania o aktualny stan urządzenia bez jego odczytania?

---

## EXP-02 — Dla chętnych: rozszerzenie możliwości Shelly

W [dokumentacji Shelly](https://shelly-api-docs.shelly.cloud/gen2/ComponentsAndServices/Switch/#switchtoggle) znajdziesz metodę `Switch.Toggle`, która
przełącza aktualny stan gniazdka.

Przykładowe wywołanie:

http://localhost:8080/rpc/Switch.Toggle?id=0

> **Uwaga:** jeśli chcesz pracować z fizycznym urządzeniem, zamiast `localhost:8080` musisz przekazać adres IP swojego Shelly.

**Zadanie:** dodaj obsługę tej operacji do kolejnych aplikacji.

1. **HTTP API** — rozszerz `00-Shelly.Simulator` o metodę
   `Switch.Toggle` i sprawdź jej działanie.

2. **Tool Calling** — rozszerz `02-Shelly.ToolCalling`, aby model
   mógł wykonać polecenie:

   > Przełącz lampkę.

Obsługę tej operacji w serwerze i kliencie MCP dodasz na
[Laboratorium 05 — MCP](../05-mcp/experiments.md#exp-01--dla-chętnych-switchtoggle-w-mcp).

**Dokumentacja:**

- [Shelly Plug S Gen3](https://shelly-api-docs.shelly.cloud/gen2/Devices/Gen3/ShellyPlugSG3)
- [Switch API](https://shelly-api-docs.shelly.cloud/gen2/ComponentsAndServices/Switch)

### Pytania

1. Czy dodanie metody do API automatycznie udostępnia ją modelowi?
2. Czy model może zrealizować polecenie „Przełącz lampkę” bez
   dedykowanego narzędzia `Switch.Toggle`?

---

## Podsumowanie

Po wykonaniu eksperymentów powinieneś rozumieć:

- jak model korzysta z narzędzi udostępnionych przez aplikację,
- jak rozszerzać możliwości modelu przez Tool Calling.

Na kolejnym laboratorium: [Laboratorium 05 — MCP](../05-mcp/README.md).

> **Nie pytamy tylko, czy model potrafi wykonać zadanie. Pytamy również, jakie możliwości musimy mu udostępnić, aby mógł je wykonać.**
