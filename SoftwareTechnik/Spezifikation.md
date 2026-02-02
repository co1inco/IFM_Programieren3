

# Funktionale requirements

| Name/ID | In meiner Rolle als ... | möchte ich ...                  | , so dass...           | Akzeptiert, wenn...       | Priorität |
| ----------------- | ----------- | --------------------------------- | ---------------------- | ------------------------- | ---- |
| user anmelden     | Benutzer    | mich bei dem Service Anmelden     | ich mich anmelden kann | User können sich anmelden | Muss |
| user registrieren | Benutzer    | mich bei dem Service registrieren | ich mich registrieren kann | User können sich registrieren | Muss |
| user username     | Benutzer    | einen benutzernahmen angeben      | dieser für mich angezeigt wird | User kann username eingeben | Kann |
| user name         | Benutzer    | Meinen legalen Namen angeben können | Rechnungen Automatisch erstellt werden können | der User seinen Namen angeben kann | Kann |
| user email        | Benutzer    | eine E-Mail angeben               | ich benachrichtigt werden kann | User kann E-Mail eingeben | Kann |
| user communication | Benutzer   | meinen bevorzugten Kommunikationsweg angeben | ich über diesen Weg wichtige Benachrichtigungen erhalten kann | der User seinen bevorzugten Kommunikationsweg angeben kann | Kann |
| user password (double) | Benutzer | ein Password angeben (zweimal)  | Schreibfehler werden vermieden | Passwort muss zweimal eingegeben werden; Mindeststärke geprüft (z.B. 8+ Zeichen, Zahl, Sonderzeichen) | Muss |
| password hash     | System      | dass mein Password gehasht und gesaltet wird | Passwörter nicht im Klartext gespeichert werden | Passwörter mit einem modernen KDF (z. B. Argon2/bcrypt) + Salt gespeichert | Muss |
| password reset    | Benutzer    | mein Passwort zurücksetzen können | ich wieder Zugriff erhalte | Reset per E‑Mail mit einmaligem Token (gültig 1 h); nach Reset erfolgt Benachrichtigung an alle aktiven Sessions | Muss |
| session & logout  | Benutzer / System | aktiv angemeldete Sessions verwalten (Logout, Session‑Timeout, Revoke) | Konten sicher bleiben, auch bei Geräteverlust | Benutzer können sich abmelden; Sessions verfallen automatisch (configurierbar); Admin kann Sessions widerrufen | Muss |
| register captcha   | System      | dass der User bei der Registrierung ein Captcha lösen muss | sich Bots nicht so einfach registrieren können | Registrierung kann optional ein Captcha verlangen (konfigurierbar) | Soll |
| E‑Mail verification | System    | dass der User bei der Registrierung seine E‑Mail überprüfen muss | E‑Mail‑Besitz ist verifiziert | Verifikationslink (24 h Gültigkeit); Konto eingeschränkt bis zur Verifikation | Muss |
| user page after login | Benutzer    | nach dem login auf eine Seite mit einer übersicht über Gruppen kommen | ich auf Anhieb eine Übersicht über meine Gruppen habe | wenn die user homepage die Gruppenübersicht ist | Muss |
| Gruppenübersicht      | Benutzer | eine übersicht über Mein, Beigetretenen und Öffentliche Gruppen haben | ich eine Übersicht über die für mich interessanten Gruppen habe | der User eine Übersicht über die Gruppen, denen er beigetreten, die er erstellt und die für ihn interessant sind, hat | Muss |
| Gruppenübersicht sortieren | Benutzer | die Liste der verfügbaren Gruppen sortieren | mir Gruppen entsprechend meines aktuellen Interesses angezeigt werden | der User die angezeigte Liste an Gruppen sortieren kann | Kann |
| Gruppenübersicht navigieren | Benutzer | durch anwählen zu der angewählten Gruppe gelangen | ich mit der Angewählten Gruppe interagieren kann | der User durch anwählen zu einer Gruppe Navigieren kann | Muss |
| Gruppe erstellen      | Benutzer | eine neue Gruppe erstellen können | eine Gruppe mit Start‑/Enddatum anlegen | Pflichtfelder: Name, Sichtbarkeit (öffentlich/privat/hidden); Ersteller = Owner; Erzeugung liefert feste Event‑URL und Join‑Code | Muss |
| Gruppe löschen (Owner) | Owner | eine selbst erstellte Gruppe löschen können | die Daten nicht mehr für Teilnehmer sichtbar sind | Nur Owner kann löschen; Lösch‑Workflow zeigt Folgen (Archivieren vs. vollständiges Löschen) und erfordert Bestätigung | Muss |
| Gruppe beitreten      | Benutzer | einer bestehenden Gruppe beitreten können | ich Teilnehmer der Gruppe werde | Beitritt per Join‑Code / Einladungs‑Link oder öffentliche Gruppe; Beitritt erscheint sofort in Mitgliederliste | Muss |
| Gruppenmitglieder     | Gruppenmitglied | sehen, wer sonst noch in der Gruppe ist | ich weiß, wer teilnimmt | Mitgliederliste mit Rollen (Owner, Admin, Member); Datenschutz: nur für berechtigte Nutzer sichtbar | Muss |
| Invite‑Code verwalten | Owner / Admin | Join‑Codes erzeugen, Ablaufdatum setzen und widerrufen | nur berechtigte Personen beitreten können | Codes haben optionales Ablaufdatum; Owner kann Codes sofort invalidieren | Muss |
| Gruppeneinladung link | Benutzer | einer Gruppe über einen festen Link beitreten können | einfache Einladung möglich ist | Einladungs‑Link ist stabil oder hat konfigurierbares Ablaufdatum; Nutzung protokolliert | Muss |
| Gruppeneinladung qr   | Benutzer | einer Gruppe über einen QR‑Code beitreten können | einfacher Beitritt via Mobilgerät | QR codiert die Event‑URL/Join‑Code; Ablaufregel wie bei Link | Kann |
| Gruppenbeschreibung setzen    | Gruppenmitglied | eine Gruppenbeschreibung setzen | klarer Kontext für die Gruppe | Beschreibung editierbar; Änderungen protokolliert; nur berechtigte Rollen dürfen großflächig bearbeiten | Kann |
| Gruppe verlassen              | Gruppenmitglied | eine Gruppe verlassen können | ich erhalte keine weiteren Benachrichtigungen | Mitglieder können selbstständig austreten; Einzahlungen werden gemäß Regeln behandelt (siehe Einzahlungs‑Policy) | Muss |
| Gruppe Mindestteilnehmer      | Owner / Admin | eine Mindestteilnehmerzahl festlegen | Event findet nur ab Mindestanzahl statt | Mindestanzahl wird angezeigt; bei Unterschreitung Benachrichtigung an Owner | Muss |
| Gruppe Mindestbetrag (vereint) | Owner / Admin | einen Mindestbeitrag für das Event festlegen | Finanzierungssicherheit des Events | Mindestbetrag sichtbar auf Event‑Homepage; System meldet "erreicht"/"offen"; automatische Aktionen (z. B. Cancel/Refund) konfigurierbar | Muss |
| Gruppe max. Einzahlung (optional) | Gruppenmitglied | optional ein System‑Limits setzen/anzeigen | Missbrauch oder Fehler vermeiden | System kann ein optionales Oberlimit pro Zahlung konfigurieren; wenn nicht gesetzt, gilt "kein Limit" | Kann |
| Gruppe Einzahlungsübersicht   | Gruppenmitglied | Übersicht über alle eingegangenen Zahlungen | ich sehe wer wie viel bezahlt hat | Tabelle mit Beträgen, Datum, Zahler; Summen und ausstehender Betrag; Export (CSV/JSON) möglich | Muss |
| Gruppe Kassensturz | Gruppenmitglied | eine Übersicht über alle Ausgaben der Gruppe habe | ich diese den Einzahlungen gegenüber stellen kann | Gruppenmitglieder eine Übersicht über die Ausgaben einer Gruppe haben | Muss | 
| Gruppe Info-Übersicht         | Gruppenmitglied | eine Chronologische übersicht über alle Notizen, Termine und Umfragen | neue Infos auf den ersten Blick erkenne | Gruppenmitglieder eine chronologische Übersicht über die Gruppeninformationen haben | Muss |
| Gruppe Info-Übersicht sortieren | Gruppenmitglied | die Angezeigten Infos sortieren können | die für mich relevanten Infos an erste stelle stehen | Gruppenmitglieder können die angezeigten Infos sortieren | Kann |
| Gruppe Notizen                | Gruppenmitglied | der Gruppe eine neue Notiz hinzufügen | ich Infos und Erlebnisse mit den anderen Gruppenmitgliedern teilen kann | Gruppenmitglieder neue Notizen hinzu fügen können | Muss |
| Gruppen Termine               | Gruppenmitglied | der Gruppe ein neues Datum als Termin hinzufügen können | ich wichtige Termine mit den anderen Gruppenmitgliedern Teilen kann | Gruppenmitglieder einer Gruppe Termine hinzufügen können | Muss | 
| Gruppenumfragen               | Gruppenmitglied | der Gruppe eine Umfrage hinzufügen können | ich die Präferenzen der anderen Gruppenmitglieder erfragen kann | Gruppenmitglieder Umfragen erstellen können | Kann |
| Umfrage type | Gruppenmitglied | Umfragen mit verschiedene Typen erstellen | ich Gruppenmitgliedern Single und Multiple choice fragen stellen | Gruppenmitglieder bei der Erstellung von Umfragen die Wahl zwischen Single und Multiple choice Aufgaben haben | Muss |
| Zufriedenheit‑Umfrage         | Gruppenersteller | nach dem Event / Urlaub eine Zufriedenheitsumfrage erstellen | ich weiß, wie zufrieden die Gruppenmitglieder mit der Planung / Durchführung des Events waren | Gruppenersteller nach einem Event eine Zufriedenheitsumfrage an die Gruppenmitglieder senden können | Kann |
| Gruppendokumentation (Media)  | Gruppenmitglied | Kommentare, Bilder und Videos hochladen | Event dokumentieren | Upload erlaubt (Whitelist‑MIME), Max‑Größe konfigurierbar, Moderations‑Flag | Kann |
| Gruppen‑Lifecycle (state machine) | Owner / System | Eventzustände (Draft→Open→Confirmed→Cancelled→Archived) verwalten | automatisierbare Abläufe möglich | Zustandsübergänge definiert; bei Cancel automatischer Refund‑Pfad / Benachrichtigung möglich | Muss |
| Zahlungs‑Webhook Idempotenz   | System      | eingehende Payment‑Events idempotent verarbeiten | keine Doppelbuchungen entstehen | Webhook‑Events mit Idempotency‑Key; wiederholte Zustellungen erzeugen kein Duplikat | Muss |
| Gruppen‑Zeitraum              | Gruppenmitglied | einen Zeitpunkt / Zeitraum festlegen | ich kommuniziere, wann das Event stattfindet | Start/End‑Datum vorhanden; Zeitzone angegeben; wiederkehrende Termine optional | Muss |

## Stage2 

| Name/ID | In meiner Rolle als ... | möchte ich ...                  | , so dass...           | Akzeptiert, wenn...       | Priorität |
| ----------------- | ----------- | --------------------------------- | ---------------------- | ------------------------- | ---- |
| Gruppen Aufgaben | Gruppenmitglied | Aufgaben erstellen | Gruppenmitglieder eine Übersicht habe, welche Aufgaben erledigt werden müssen | eine Gruppe eine Übersicht über die Aufgaben hat | Muss |
| Gruppenaufgabe zuweisen | Gruppenmitglied | bestehende Aufgaben einem Gruppenmitglied zuweisen | das Mitglied weiß, welche Aufgaben es noch zu erledigen hat | Gruppenmitgliedern Aufgaben zugewiesen werden können | Muss |
| Gruppenaufgabe beenden | Gruppenmitglied | eine Aufgabe als erledigt markieren | ersichtlich ist, welche Aufgaben noch zu erledigen sind | ein Gruppenmitglied eine Aufgabe als erledigt markieren kann | Muss |
| Gruppenaufgabe Erinnerung | Gruppenmitglied | eine automatische Erinnerung über unerledigte Aufgaben bekomme, denen ich zugewiesen bin. Die Benachrichtigung soll über meinen bevorzugten Kommunikationskanal bekommen | ich an Unerledigte Aufgaben erinnert werde | Gruppenmitglieder bekommen Erinnerungen über ihren bevorzugten Kommunikationskanal | Kann |
| Gruppenrechte | Gruppen-Owner | Berechtigungen für Gruppenmitglieder festlegen können | ich Steuern kann, welche Gruppenmitglieder welche Operationen Ausführen können | ein Gruppen-Owner die Zugriffsberechtigungen [Owner; Admin; User] einzelnen Gruppenmitglieder zuweisen | Muss |
| Gruppen-Owner | Gruppenersteller | automatisch der Besitzer einer Gruppe sein | ich alle relevanten Einstellungen treffen kann | der Ersteller einer Gruppe nach dem erstellen der Gruppen-owner is | Muss |
| Gruppenmitglied entfernen | Gruppenamin | Als Gruppenadmin möchte ich einzelne Gruppenmitglieder aus der Gruppe entfernen | ich störende Nutzer aus der Gruppe entfernen kann | Gruppenadmins einzelne Gruppenmitglieder aus der Gruppe entfernen können | Muss |
| Community-Edition | User | Zugriff auf eine Kostenlose Variante des Services haben | ich bis zu drei Gruppen Kostenlos, nicht zeitgleich erstellen kann | "Community" Nutzer können Kostelos bis zu 3 Gruppen erstellen, die nicht zeitgleich stattfinden | Muss |
| premium-Edition | user | Zugriff auf eine Premium Variante des Services haben | so dass ich unbegrenzt viele und zeitgleiche Gruppen erstellen kann | ein Premium Nutzer unbegrenzt viele Gruppen erstellen kann, welche zeitgleich stattfinden können | Muss |
| Smartphone | User | den Service über ein Smartphone verwenden | ich den Service Unterwegs verwenden kann | der Service über ein Smartphone verwendet werden kann | Muss |
| Desktop | User | den Service über eine Webbrowser auf meinem Desktop verwenden | ich den Service von meinem Computer verwenden kann | der Service über ein webbrowser verwendet werden kann | Muss |
| Funktionale-Parität | User | Alle Endgeräte sollen mir Zugriff auf die gleichen Funktionen geben | ich in der Wahl des Endgerätes frei bin | alle Platformen [Smartphone; Desktop-Webborwser] die gleichen Funktionen bieten | Muss |






