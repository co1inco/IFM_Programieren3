

# Funktionale requirements

| Name/ID | In meiner Rolle als ... | möchte ich ...                  | , so dass...           | Akzeptiert, wenn...       | Priorität |
| ----------------- | ----------- | --------------------------------- | ---------------------- | ------------------------- | ---- |
| user anmelden     | Benutzer    | mich bei dem Service Anmelden     | ich mich anmelden kann | User können sich anmelden | Muss |
| user registrieren | Benutzer    | mich bei dem Service registrieren | ich mich registrieren kann | User können sich registrieren | Muss |
| user username     | Benutzer    | einen benutzernahmen angeben      | dieser für mich angezeigt wird | User kann username eingeben | Kann |
| user name         | Benutzer    | Meinen legalen Namen angeben können | Rechnungen Automatisch erstellt werden können | der User seinen Namen angeben kann | Kann |
| user email        | Benutzer    | eine E-Mail angeben               | ich benachrichtigt werden kann | User kann E-Mail eingeben | Kann |
| user communication | Benutzer   | meinen bevorzugten Kommunikationsweg angeben | ich über diesen Weg wichtige Benachrichtigungen erhalten kann | der User seinen bevorzugten Kommunikationsweg angeben kann | Kann |
| user password     | Benutzer    | ein Password angeben              | nicht jeder auf meine Benutzerdaten zugreifen kann | User kann Password angeben | Muss |
| password hash     | Benutzer    | das mein Password gehascht wird   | mein Password bei einem Datenleck nicht verloren gehen kann | Passwörter werden gheascht und gesaltet | Muss |
| double password   | Benutzer    | das ich mein Password der Aktualisierung zwei mal angeben muss | ein Schreibfehler auffällt | Password muss 2 mal eingegeben werden | Kann |
| register captcha      | System      | dass der User bei der Registrierung ein captcha lösen muss | sich Bots nicht so einfach registrieren könne | der Registrierprozess ein captcha benötigt | Muss |
| E-Mail verification   | System    | dass der User bei der Registrierung seine E-Mail überprüfen muss | sichergestellt ist, dass die E-Mail gültig und im besitzt des Users ist | der User bei der Registrierung beweisen muss, dass er unsere Mails empfangen kann | Muss |
| user page after login | Benutzer    | nach dem login auf eine Seite mit einer übersicht über Gruppen kommen | ich auf Anhieb eine Übersicht über meine Gruppen habe | wenn die user homepage die Gruppenübersicht ist | Muss |
| Gruppenübersicht      | Benutzer | eine übersicht über Mein, Beigetretenen und Öffentliche Gruppen haben | ich eine Übersicht über die für mich interessanten Gruppen habe | der User eine Übersicht über die Gruppen, denen er beigetreten, die er erstellt und die für ihn interessant sind, hat | Muss |
| Gruppenübersicht sortieren | Benutzer | die Liste der verfügbaren Gruppen sortieren | mir Gruppen entsprechend meines aktuellen Interesses angezeigt werden | der User die angezeigte Liste an Gruppen sortieren kann | Kann |
| Gruppenübersicht navigieren | Benutzer | durch anwählen zu der angewählten Gruppe gelangen | ich mit der Angewählten Gruppe interagieren kann | der User durch anwählen zu einer Gruppe Navigieren kann | Muss |
| Gruppe erstellen      | Benutzer | eine neue Gruppe erstellen können | ich eine neue Gruppe erstellt habe | der User eine neue Gruppe erstellen kann | Muss |
| Gruppe löschen        | Benutzer | eine selbst erstellte Gruppe löschen können | diese Gruppe nicht mehr sichtbar ist | der User selbst erstellte Gruppen löschen kann | Kann |
| Gruppe beitreten      | Benutzer | einer Bestehenden Gruppe beitreten können | Teilnehmer dieser Gruppe werde | ein User eine Gruppe beitreten kann | Muss |
| Gruppenmitglieder     | Gruppenmitglied | als Gruppenmitglied möchte sehen, wer sonnst noch in der Gruppe ist | ich weiß, wer noch in der Gruppe ist | ein Gruppenmitglied eine Mitgliederliste einsehen kann | Muss |
| Gruppeneinladung link | Benutzer | einer Gruppe über einen festen Link beitreten können | ich die Gruppe nicht manuell suchen muss | Gruppenmitglieder zugriff auf einen Link haben, über den sie User einladen können und der sich nicht ändert | Kann |
| Gruppeneinladung qr   | Benutzer | einer Gruppe über einen QR-Code beitreten können | ich die Gruppe nicht manuell suchen muss | Gruppenmitglieder zugriff auf einen QR-Code haben, über den sie User einladen können | Kann |
| Gruppenbeschreibung setzen    | Gruppenmitglied | eine Gruppenbeschreibung setzen | jeder User sehen kann, wo rum es in der Gruppe geht | Gruppenmitglieder können die Beschreibung einer Gruppe bearbeiten | Kann | 
| Gruppe verlassen              | Gruppenmitglied | eine Gruppe verlassen können | sie nicht mehr in meiner Übersicht auftaucht und ich keine Benachrichtigungen mehr bekomme | ein User eine Gruppe, der er vorher beigetreten ist, wieder verlassen kann | Kann | 
| Gruppe Mindestteilnehmer      | Gruppenmitglied | eine Mindestteilnehmerzahl festlegen | um festlegen zu können, ab wie vielen Teilnehmern ein Event / Urlaub erst stattfinden kann | Gruppenmitglieder eine Mindest-Teilnehmerzahl festlegen können | Kann |
| Gruppe Mindestbetrag          | Gruppenmitglied | eine Mindestbetrag festlegen | ich festlegen kann, view viel mindestens Eingezahlt werden muss, damit ein Event / Urlaub stattfinden kann | Gruppenmitglieder einen Mindestbetrag festlegen können | Kann |
| Gruppe maximale einzahlung    | Gruppenmitglied | einen beliebig hohen Betrag in eine Gruppe einzahlen | ich beliebig viel Geld in eine Gruppe einzahlen kann | es kein Limit für den maximal einzahlbaren Betrag gib | Kann |
| Gruppe Mindesteinzahlung      | Gruppenmitglied | einen Minimalbetrag festlegen | Gruppenmitglieder nicht beliebig kleine Geldsummen einzahlen können | Gruppenmitglieder einen Minimalbetrag festlegen können | Kann |
| Gruppe Einzahlungsübersicht   | Gruppenmitglied | eine übersicht über alle eingegangenen Zahlungen haben | ich überprüfen kann, wer vie viel Gesendet hat | es für Gruppenmitglieder eine übersicht über die Einzahlungen gibt | Muss |
| Gruppe Info-Übersicht         | Gruppenmitglied | eine Chronologische übersicht über alle Notizen, Termine und Umfragen | neue Infos auf den ersten Blick erkenne | Gruppenmitglieder eine chronologische Übersicht über die Gruppeninformationen haben | Muss |
| Gruppe Info-Übersicht sortieren | Gruppenmitglied | die Angezeigten Infos sortieren können | die für mich relevanten Infos an erste stelle stehen | Gruppenmitglieder können die angezeigten Infos sortieren | Kann |
| Gruppe Notizen                | Gruppenmitglied | der Gruppe eine neue Notiz hinzufügen | ich Infos und Erlebnisse mit den anderen Gruppenmitgliedern teilen kann | Gruppenmitglieder neue Notizen hinzu fügen können | Muss |
| Gruppen Termine               | Gruppenmitglied | der Gruppe ein neues Datum als Termin hinzufügen können | ich wichtige Termine mit den anderen Gruppenmitgliedern Teilen kann | Gruppenmitglieder einer Gruppe Termine hinzufügen können | Muss | 
| Gruppenumfragen               | Gruppenmitglied | der Gruppe eine Umfrage hinzufügen können | ich die Präferenzen der anderen Gruppenmitglieder erfragen kann | Gruppenmitglieder Umfragen erstellen können | Kann |
| Zufriedenheit-Umfrage         | Gruppenersteller | nach dem Event / Urlaub eine Zufriedenheitsumfrage erstellen | ich weiß, wie zufrieden die Gruppenmitglieder mit der Planung / Durchführung des Events waren | Gruppenersteller nach einem Event eine Zufriedenheitsumfrage an die Gruppenmitglieder senden können | Kann |
| Gruppendokumentation          | Gruppenmitglied | Kommentare, Bilder und Videos hochladen können | ich das Event / den Urlaub mit den anderen Mitgliedern Teilen kann | Gruppenmitglieder einer Gruppe Kommentare hinzufügen können | Kann |
| Gruppen-Zeitraum              | Gruppenmitglied | einen Zeitpunkt / Zeitraum für die Gruppe festlegen | ich Kommunizieren kann, wann das Event stattfindet | Gruppenmitglieder einen Zeitraum für das Hauptevent der Gruppe festlegen können | Muss |
 








