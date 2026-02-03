
1. Titelblatt, Autoren, Selbstständigkeitserklärung
2. Executive Summary (Ziele, Scope, wichtige Annahmen)
3. Glossar / Domain‑Begriffe
4. Functional requirements (User‑Stories + komplette Tabelle) ← zentrale Stelle
   + 4.1 Mapping User‑Stories → Akteure (Use‑Case‑Kurzliste)
   + 4.2 Akzeptanztests / Test‑Cases (pro Story)
5. 4+1 Sichten (jeweils: Ziele, Hauptdiagramme, Mapping zu Stories)
   + 5.1 Use‑case / Szenarien (the „+1“): Use‑case‑Diagramme, Hauptszenarien, Sequenzdiagramme, Acceptance‑Criteria links
   + 5.2 Logical View: Domänen‑Klassendiagramm, ER/DB‑Modell, CRUD‑Matrix, VIF/Relationen
   + 5.3 Development View: Komponenten/Module, Paketstruktur, API‑Contract (OpenAPI), Build/ * Repo‑Struktur
   + 5.4 Process View: Laufzeit‑Architektur, Threads/Queues, State‑Machines (z. B. Group  * lifecycle), Sequence/Activity für kritische Flows
   + 5.5 Physical (Deployment) View: Deployment‑Diagramm, Infra‑Services, Sizing & SLOs
 1. Nicht‑funktionale Anforderungen (NFR) — messbar (Performance, Security, Privacy, Availability,  * Scalability)
 1. Security & Privacy (STRIDE, Datenschutz, Encryption, Aufbewahrung)
 1. API & Integration (OpenAPI, Webhooks, Idempotenz, Drittanbieter)
 1. Operations & SRE (Monitoring, Backups, Runbook, SLA/SLO)
 1. Testplan / QA (Akzeptanztests, CI/CD‑Pipelines, E2E‑Matrix)
 1. Open decisions / Risks / Roadmap (TODOs, Annahmen)
 1. Anhänge: UML‑Quellen, DB‑Schema SQL, Mockups, Beispiel‑API‑Responses, Traceability‑Matrix


# 2 - Zusammenfassung
Ziel ist es, einen Service zu entwickeln, der es Leuten die Planung von Events und Urlauben zu vereinfachen. Diese Events benötigen häufig die Organisation einer größeren Gruppe an Personen. Unser Service soll den Leuten genau diese Absprachen und Organisation erleichtern. Die Nutzer sollen eine Gruppe zur Organisation solcher Events erstellen oder bereits bestehenden Gruppen beitreten können. Eine solche Gruppe bietet den Mitgliedern dann die Möglichkeit, sich mittels Chats, Terminen und Umfragen abzusprechen. Außerdem soll es möglich sein, über eine Gruppe Gelder einzusammeln und Ausgaben zu Organisieren. Außerdem sollen Veranstaltungsdienstleister über die Platform ihre Dienste anbieten können. Gruppen können die Dienstleiter dann für die Organisation des Events Buchen. Unsere Platform soll den Dienstleistern außerdem die Möglichkeit geben Mitarbeiter und Materialien zu Organisieren.


# 5 - Funktionale requirements

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
| Gruppen: Aufgaben (create) | Gruppenmitglied | Aufgaben erstellen | Team-Aufgaben verwaltbar sind | Neue Aufgabe wird in Gruppen-Task‑Liste angezeigt; Pflichtfelder: Titel, Fälligkeitsdatum; API-Response 201 | Muss |
| Gruppen: Aufgabe zuweisen | Gruppenmitglied | Aufgaben einem Mitglied zuweisen | Zuständigkeiten klar sind | Zuweisung ändert Task-Status; Benachrichtigung an Empfänger innerhalb 5 min | Muss |
| Gruppen: Aufgabe abschließen | Gruppenmitglied | Aufgabe als erledigt markieren | Aufgabenstatus aktuell ist | Statuswechsel sichtbar für alle Mitglieder; Änderungs-Log vorhanden | Muss |
| Aufgaben: Erinnerungen (configurable) | Gruppenmitglied | Erinnerungen per bevorzugtem Kanal erhalten | Deadlines nicht verpasst werden | Erinnerung per E‑Mail/Push/SMS laut Präferenz; konfigurierbar; Zustellung innerhalb 5 min vor Fälligkeit (configurable) | Kann |
| Rollen & Rechte (RBAC Basis) | Gruppen-Owner | Rollen (Owner/Admin/Member) vergeben | Zugriff und Aktionen steuerbar sind | Owner kann Rollen ändern; Berechtigungen enforced (z. B. nur Owner kann Gruppe löschen) | Muss |
| Owner auto‑assignment | Gruppenersteller | nach Erstellung Owner sein | Einstellungen verwalten zu können | Ersteller ist Owner; Owner-Flag in DB gesetzt | Muss |
| Mitgliederverwaltung | Gruppen-Admin | Mitglieder entfernen / einladen | Moderation möglich ist | Admin kann Mitglied entfernen; Aktion audit‑logged; entfernte Nutzer verlieren Zugriff sofort | Muss |
| Editions: Community / Premium | User | freie / kostenpflichtige Pläne nutzen | Produkt‑Limits durchsetzen | Community: ≤3 aktive Gruppen; Premium: keine Limit; Abrechnung aktiviert für Premium | Muss |
| Multi‑device parity | User | gleiches Funktionsset auf allen Geräten | konsistente UX | Kernfunktionen auf Mobile/Web verfügbar; responsives Layout (breakpoints) | Muss |
| Dienstleister: Listing & Angebot | Dienstleister | Dienstleistung einstellen & Angebot erstellen | Veranstalter finden passende Anbieter | Listing mit Pflichtfeldern; Angebot enthält Preise (Netto/Brutto), Positionen, Fotos; Download als PDF möglich | Muss |
| Dienstleister: Buchung & Budget | Gruppenmitglied | Dienstleister buchen; Budget setzen | Planung & Kostenkontrolle möglich | Buchung erzeugt Reservierung; Budget‑Limit verhindert Überbuchung; Bestätigung & Storno‑API vorhanden | Muss |
| Dienstleister: Ressourcen & Mitarbeiter | Dienstleister | Material & Personal verwalten | Verfügbarkeit planbar ist | Ressourcen können geblockt/entblockt werden; Mitarbeiter‑Calendar sichtbar; Konflikte verhindert | Muss |
| Bewertungen & Feedback | Gruppenmitglied | Dienstleister bewerten | Qualität transparent wird | Bewertung nur nach abgeschlossenem Event; Anzeige mittelt Bewertungen; Missbrauchs-Moderation möglich | Kann |
| Material‑Lifecycle (Wartung) | Dienstleister | Wartungszyklen verwalten | Ausfälle planbar sind | Wartungs‑Reminder configurable; Historie pro Asset vorhanden | Muss |
| Abrechnung: Rechnung + Mahnwesen | Dienstleister / Organisator | Rechnungen automatisch erzeugen / Mahnungen senden | Zahlungen eingetrieben werden | Rechnung generiert aus Angebot; PDF/CSV-Export; Mahnung nach konfigurierbarer Frist (z. B. 30 Tage) | Muss |
| DSGVO – Datenexport & Löschung | Benutzer | meine Daten exportieren/ löschen lassen | Recht auf Auskunft / Vergessenwerden erfüllt ist | User kann vollständigen Datenexport (JSON/CSV) anfordern; Löschung führt zu Anonymisierung/Entfernung innerhalb 30 Tage; Audit-Log der Anfrage | Muss |
| Sicherheit: Auth & Sessions | Benutzer/System | 2‑Faktor, Session‑Timeout, Account‑Lockout | Konten sicher sind | Passwort-Hashing mit Argon2/bcrypt; 2FA optional; Session default 30 min idle; Account lock after 5 failed attempts (configurable) | Muss |
| Payments: Webhook Idempotenz & Refunds | System | sichere Zahlungsabwicklung | keine Doppelbuchungen; Rückerstattungen möglich | Webhooks idempotent; Refunds via API in <72 h; reconciliations reportierbar | Muss |
| Observability & Ops | Betreiber | Monitoring, Logging, Backups | Betriebssicherheit gewährleistet | 99.5% availability target (SLA); zentrale Logs (retention 90d); tägliche Backups; Alerts bei Fehlern | Soll |
| API: Contract & Rate Limits | Integrator | stabile API nutzen | Integration zuverlässig bleibt | OpenAPI spec vorhanden; 95th pct response <500ms; rate limit 1000 req/min per API key | Soll |
| Accessibility (WCAG) | User | barrierefreien Zugang haben | inklusiver Betrieb | WCAG 2.1 AA für Kern-User‑Flows | Soll |
| Testing & CI/CD | Entwickler | automatisierte Qualitätssicherung | Regressionen verhindert werden | Unit/Integration/E2E in CI; PRs müssen CI grünes Licht haben | Muss |

### Ergänzende nicht‑funktionale Anforderungen (Auswahl / messbar)
- Performance: 95th‑percentile API latency < 500 ms für Kernendpunkte (list/create/join).
- Skalierbarkeit: System skaliert horizontal bei 50% CPU‑Auslastung der Instanzgruppe.
- Sicherheit: TLS 1.2+ enforced; Secrets in KMS; regelmäßige Pen‑Tests (Jährlich).
- Datenschutz: Datenexport (JSON/CSV), Lösch‑Workflow, Einwilligungs‑Logging für E‑Mails.

### Quick checklist (für Review)
1. Alle User Stories haben prüfbare Akzeptanzkriterien? — (✓) größtenteils; offene Punkte in TODO.
2. DSGVO‑spezifische Stories vorhanden? — (✓)
3. Nicht‑funktionale Anforderungen (verfügbar, messbar)? — (✓)
4. Vorschlag: für jede "Soll"/"Muss"‑Story einen Implementierungs‑Task + Tests definieren.

<!-- Ende Stage2 (überarbeitet) -->


