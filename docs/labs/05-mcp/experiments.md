# Laboratorium 05 — MCP

## Eksperymenty

### Pytanie przewodnie

> Jak zaprojektować serwer MCP, który udostępnia narzędzia, dane i prompty?

Podczas eksperymentów będziesz rozwijać istniejący serwer MCP dla urządzenia Shelly.

Wykorzystasz MCP Inspector do sprawdzania jego możliwości.

| Eksperyment | Temat | Forma |
|---|---|---|
| EXP-00 | Poznaj serwer MCP | Ćwiczenie |
| EXP-01 | Tools — odczyt poboru mocy | Zadanie programistyczne |
| EXP-02 | Resources — informacje o urządzeniu | Zadanie programistyczne |
| EXP-03 | Prompts — raport kosztów energii | Zadanie programistyczne |
| EXP-04 | MCP Client | Ćwiczenie |
| Dodatkowy | Zaprojektuj własny interfejs MCP | Zadanie projektowe |

---

## EXP-00 — Poznaj serwer MCP

### Cel

Poznaj sposób komunikacji klienta z serwerem MCP.

### Zadania

1. Uruchom symulator Shelly.
2. Uruchom MCP Inspector.
3. Połącz Inspector z serwerem `03-Shelly.Mcp`.
4. Odkryj dostępne narzędzia.
5. Sprawdź ich nazwy, opisy i argumenty.
6. Wywołaj narzędzie włączające lampkę.
7. Odczytaj aktualny stan urządzenia.
8. Wyłącz lampkę.

### Pytania

1. Czy MCP Inspector korzysta z modelu językowego?
2. Skąd Inspector zna listę narzędzi?
3. Czy serwer MCP musi znać klienta, który się z nim łączy?
4. Co się stanie, gdy symulator Shelly przestanie odpowiadać?

---

## EXP-01 — Tools

### Cel

Rozszerz serwer MCP o nowe narzędzie.

### Problem

Shelly potrafi informować o aktualnym poborze mocy.

Chcemy udostępnić tę informację klientom MCP.

Użytkownik pyta:

> Ile watów pobiera teraz lampka?

### Zadania

1. Zapoznaj się z istniejącymi narzędziami w `03-Shelly.Mcp`.
2. Sprawdź, jak Shelly udostępnia informację o poborze mocy.
3. Dodaj narzędzie umożliwiające odczyt aktualnej mocy.
4. Uruchom ponownie serwer MCP.
5. Odkryj nowe narzędzie przez MCP Inspector.
6. Wywołaj je przy włączonej i wyłączonej lampce.
7. Porównaj wyniki.

### Pytania

1. Skąd klient wie, jakie argumenty przyjmuje narzędzie?
2. Czy dodanie narzędzia wymaga zmiany kodu MCP Inspector?
3. Czy opis narzędzia wpływa na jego działanie w Inspectorze?
4. Czy opis może wpływać na decyzję modelu językowego?

---

## EXP-02 — Resources

### Cel

Udostępnij informacje o urządzeniu jako zasób MCP.

### Problem

Klient MCP potrzebuje informacji o urządzeniu:

- nazwa,
- model,
- lokalizacja,
- opis przeznaczenia.

Nie chcemy jednak tworzyć osobnego narzędzia do pobierania każdej informacji.

### Zadania

1. Sprawdź w dokumentacji MCP, czym są Resources.
2. Zapoznaj się ze sposobem definiowania zasobów w C# SDK.
3. Rozszerz `03-Shelly.Mcp` o zasób:

   ```text
   shelly://device/info
   ```

4. Udostępnij w nim informacje o urządzeniu.
5. Uruchom serwer MCP.
6. Otwórz zakładkę Resources w MCP Inspector.
7. Odkryj nowy zasób.
8. Odczytaj jego zawartość.

### Pytania

1. Czym Resource różni się od Tool?
2. Czy odczyt Resource wymaga modelu językowego?
3. Kto decyduje, kiedy odczytać Resource?
4. Czy zawartość Resource może się zmieniać?
5. Czy informacje o aktualnym poborze mocy również można udostępnić jako Resource?

### Do przemyślenia

> Czy informacja o stanie lampki powinna być Tool czy Resource?

Uzasadnij swoją decyzję.

---

## EXP-03 — Prompts

### Cel

Udostępnij szablon promptu przez MCP.

### Problem

Chcemy umożliwić użytkownikowi przygotowanie raportu kosztów użytkowania lampki.

Raport powinien uwzględniać:

- moc urządzenia,
- czas użytkowania,
- cenę energii,
- szacowany koszt.

### Zadania

1. Sprawdź w dokumentacji MCP, czym są Prompts.
2. Zapoznaj się ze sposobem definiowania promptów w C# SDK.
3. Dodaj do `03-Shelly.Mcp` prompt:

   ```text
   energy-report
   ```

4. Zdefiniuj argumenty:

   - `hours` — liczba godzin,
   - `pricePerKwh` — cena energii za kWh.

5. Przygotuj szablon instrukcji generowania raportu.
6. Uruchom serwer MCP.
7. Otwórz zakładkę Prompts w MCP Inspector.
8. Odkryj nowy prompt.
9. Pobierz jego zawartość, przekazując argumenty.

### Pytania

1. Czy pobranie MCP Prompt uruchamia model językowy?
2. Czy MCP Prompt wykonuje obliczenia?
3. Czym różni się MCP Prompt od zwykłego promptu?
4. Czy serwer MCP musi znać model, który wykorzysta prompt?
5. Kto odpowiada za przekazanie promptu do modelu?

---

## EXP-04 — MCP Client

### Cel

Sprawdź, jak aplikacja .NET wykorzystuje możliwości serwera MCP.

### Zadania

1. Uruchom `04-Shelly.McpClient`.
2. Sprawdź, jak klient odkrywa narzędzia serwera.
3. Przetestuj polecenia:

   > Włącz lampkę.

   > Czy lampka jest teraz włączona?

   > Ile watów pobiera teraz lampka?

4. Sprawdź, czy klient automatycznie odkrywa narzędzie dodane w EXP-01.
5. Zapoznaj się z możliwościami odczytywania Resources i Prompts przez klienta MCP.
6. Sprawdź, czy istniejąca aplikacja obsługuje te możliwości.

### Pytania

1. Czy dodanie nowego Tool wymaga modyfikacji klienta?
2. Czy Resources są automatycznie przekazywane do modelu?
3. Czy model automatycznie wybiera MCP Prompts?
4. Jakie zmiany w aplikacji byłyby potrzebne, aby wykorzystać Resource i Prompt?

---

## Eksperyment dodatkowy — zaprojektuj własny interfejs MCP

Wyobraź sobie, że projektujesz serwer MCP dla systemu zarządzania budynkiem.

System udostępnia:

1. Włączenie oświetlenia.
2. Odczyt aktualnej temperatury.
3. Dokumentację techniczną budynku.
4. Przygotowanie raportu zużycia energii.
5. Listę dostępnych pomieszczeń.
6. Zmianę temperatury ogrzewania.

### Zadanie

Zaproponuj, które możliwości udostępnisz jako:

- Tools,
- Resources,
- Prompts.

Uzasadnij swoje decyzje.

Czy niektóre informacje można udostępnić na więcej niż jeden sposób?

---

## Podsumowanie

Po wykonaniu eksperymentów powinieneś potrafić:

- odkrywać możliwości serwera MCP,
- definiować i testować Tools,
- udostępniać Resources,
- udostępniać Prompts,
- wykorzystywać MCP Inspector,
- odróżniać możliwości protokołu MCP od możliwości modelu językowego.

### Najważniejsze pytanie

> **Czy MCP jest protokołem komunikacji z modelem językowym, czy protokołem udostępniania możliwości aplikacji?**