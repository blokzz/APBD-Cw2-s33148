# APBD-Cw2-s33148
 
Aplikacja konsolowa w C# wspierająca zarządzanie wypożyczalniami sprzętu (laptopy, projektory, aparaty) z uwzględnieniem różnych typów użytkowników i limitów biznesowych.


# 1. Separation of Concerns
Podzieliłem aplikację na wyraźne warstwy:

Models: Czyste klasy danych (User, Device, Rental). Zawierają logikę dotyczącą wyłącznie danego obiektu (np. naliczanie kary w Rental).

Repositories: Warstwa dostępu do danych. Repozytoria udają kolekcje obiektów w pamięci, dzięki czemu serwisy nie wiedzą, gdzie dane są zapisywane.

Services:Koordynują procesy biznesowe, takie jak wypożyczanie czy zwroty, komunikując się z wieloma repozytoriami naraz.

UI (MenuService): Odpowiada wyłącznie za interakcję z użytkownikiem przez konsolę.

# 2. Wykorzystanie zasad SOLID
Każda klasa ma jedno zadanie. RentalRepository tylko przechowuje dane, a RentalService tylko nimi zarządza zgodnie z regułami.

Limity wypożyczeń są zdefiniowane jako właściwości polimorficzne w klasie User. Dzięki temu RentalService nie musi sprawdzać if (user is Student), co pozwala na łatwe dodanie nowych typów użytkowników w przyszłości.

Serwisy zależą od interfejsów (IUserRepository), a nie od konkretnych klas. Pozwala to na łatwą podmianę bazy danych (np. na JSON) bez zmiany logiki serwisów.

# 3. Kohezja i Coupling (Spójność i Sprzężenie)
Wysoka Kohezja: Klasy takie jak Hardware grupują tylko cechy wspólne dla urządzeń, a specyficzne cechy (np. jasność lampy) znajdują się w klasach pochodnych.

Niskie Sprzężenie: Dzięki wstrzykiwaniu zależności (Dependency Injection), klasy nie tworzą się nawzajem (brak new wewnątrz serwisów), co ułatwia ich wymianę i testowanie.

# Reguły Biznesowe
Limity: Student (2), Pracownik (5).
Kary: Naliczane za każdy dzień zwłoki po upływie 14 dni od wypożyczenia.
Centralizacja: Wszystkie stałe (stawki kar, limity) znajdują się w klasie Configuration/BusinessRules.cs.
