# Tworzenie agentów AI w .NET

## Laboratorium 10 — Eksperymenty

### Architektura agentów AI

---

**Marcin Sulecki**  
marcin.sulecki@pw.edu.pl

Eksperymenty wykonujemy na przykładach z repozytorium [Shelly](https://github.com/sulmar/shelly).

Przed rozpoczęciem przygotuj środowisko zgodnie z [README.md](./README.md).

## Eksperymenty

| Eksperyment | Temat | Forma |
|---|---|---|
| EXP-01 | Agent AI — włączenie lampki na określony czas | Zadanie problemowe i programistyczne |

---

## EXP-01 — Agent AI

**Cel:** zrozumienie, jak możliwości agenta zależą od dostępnych narzędzi.

Uruchom aplikację `05-Shelly.Agent`.

Sprawdź działanie polecenia:

> Upewnij się, że lampka jest włączona.

Zaobserwuj, czy agent sprawdza aktualny stan urządzenia i weryfikuje rezultat działania.

### Zadanie

Użytkownik chce wydać polecenie:

> Włącz lampkę na 5 sekund, a następnie ją wyłącz.

**Rozszerz aplikację tak, aby agent potrafił samodzielnie zrealizować takie polecenie.**

Nie implementuj na stałe sekwencji włączania i wyłączania lampki.

Agent powinien samodzielnie zdecydować, jakie działania wykonać i w jakiej kolejności.

**Wymagania:**

- Zidentyfikuj ograniczenia obecnego rozwiązania.
- Zaproponuj sposób rozszerzenia możliwości agenta.
- Zaimplementuj rozwiązanie.
- Sprawdź polecenia z różnymi czasami.
- Zweryfikuj końcowy stan lampki.

**Pytanie:** czy do rozwiązania problemu potrzebny jest lepszy model, zmiana promptu czy dodatkowe narzędzie?

---

## Podsumowanie

Po wykonaniu eksperymentu powinieneś rozumieć:

- dlaczego agent potrzebuje odpowiednio zaprojektowanego środowiska.
