

4 + 1-Schichten-Softwarearchitekturmodel

# Beschreibung

Software zur Planung von Events und Urlaubsgruppen für Private und Firmen.

Inhalt:
 * Orte
 * Finanzen
 * Absprachen


## User management
 * Anmelden: Username, Password
 * Registrieren: 
   + (Vor)name, 
   + E-Mail, 
   + Benutzername, 
   + Password (zwei mal)
   + Bevorzugter Kommunikationsweg (SMS, E-Mail, Whatsapp)
   + Captcha
   + E-Mail Verifikation
 * Password: Hash und Salt
 * Password zurücksetzen
  
## User home page (seite nach anmeldung)
 * Gruppenübersicht (Erstellt, Beigetreten, beiterten möglich), Liste sortierbar
  
## Gruppe / Event
 * Gruppen erstellen (eine, oder mehrere)
    + Gruppen name
    + Beschreibung
    + Zeitbegrenzung (Nach ablauf der Zeit werden sie Gelöscht oder Archiviert)
 * Gruppen löschen (selbst erstellt)
 * Gruppenmitglieder
 * User zur Gruppe einladen (Automatisch generierter beitrittscode)
 * Mitglied kann Gruppe verlassen
 * Mindestanzahl an Mitgliedern, damit event statt findet.
 * Mindestanzahl an Eingengangenen Zahlungen, damit event statt findet
 * Teilnehmer kann beliebig hohe Geldsumme (mindestbetrag)
 * Anzeige eingegangener Geldbetrag
 * Anzeige Mindestsumme
 * Anzeige Fehlender geldbetrag
 * Eindeutige url zu event
 * QR code mit url zum event
 * Notizen zu events (Erstellen, Modifizieren, löschen)
 * Notizen sortiert nach Erstellungsdatum (Neuste zuerst)
 * Notizen Filtern
 * Umfragen
 * Termine (Incl. wichtige Daten)
 * Umfragen und Termine Zählen asl Notizen
 * Umfrage als Feedback zur Meinungs- und Zufriedenheitserfassung
 * Dokumentation mittels Kommentare, Bewertungen, Bildern, Videos
 * Datum / Start & End Datum


### Termine 
 * Syncronisierung nach Google, Outlook oder iCal

### Aufgaben
 * Aufgaben festlegen, wenn Mindestanvorderungen für event erreicht wurden
 * Aufgaben als fertig markieren
 * Verantworlichen für Aufgabe festlegen
 * Automatische Erinnerungen versenden, falls nicht erledigt

### Umfragen
 * Multiple oder Single Choise Fragen

### Ausgaben
 * Übersicht. Wer hat vie viel bezahlt
 * Einzahlungen
 * Kassensturz (Übersicht über alle ausgaben)
 * Einzahlungen von mitglied müssen gelöscht werden, wenn dieses die gruppe verlässt

### Einzahlungen
 * Dankmeldung über bevorzugten Kommunikationsweg
  
### Kommunikation
 * Kommunikationsmöglichkeit zwischen Teilnehmern

### Rechte-system 
 * Vor allem für Institutionen
 * Admin / Gruppenleiter und User einer Gruppe
 * Ersteller ist der Gruppenleiter
 * Admin kann user entfehrnen
 * Admin kann user sperren (Note: was ist der unterschied zwischen sperren und entfernen?)
 * Admin kann Gruppe verwalten

## Kommerziell

### Kostenlos / Community
 * Institutionen können max 3 Veranstaltungen durchführen
 * Zeitgleiche events nicht möglich
  
### Premium
 * Beliebig viele veranstaltungen
 * Mehrere events die Gleichzeitig statt finden

## Integration
 * Veranstaltungsdienstleisern
 * Ticketanbieter

## Veranstaltungsdienstleisern
 * Zeitliche / Logistische planung
 * Organisator kann maximalbudget festlegen
 * Dienstleister hat einen QR Code, über den ein Veranstalter ihn anfragen kann
 * Veranstalter kann dienstleister bewerten
 * Bewertungen für Dienstleister werden auf der Seite angezeigt
 * Sollen gesetztes Budget einhalten
 * Rechnungen automatisch generieren
 * Rechnung 
 * Angebote automatisch generieren
 * Aus einer Anfrage wird ein Angebot generiert, sobalt der Veranstallter das Event geplant hat
 * Kann Material (Boxen, LKWs)  verwalten
 * Kann Mitarbeiter verwalten (einem event hinzufügen)
 * 
  
### Mitarbeiter 
 * Mitarbeiter müssen geblockt werden
 * Mitarbeiter werden über event informiert
 * Mitarbeiter Qualifizeirungsgrad und Fachgebiet (Licht, Ton, MedienTechnik)
 * Mitarbeiter sollen Zeit / Arbeitspaln bekommen

### Material
 * Eigenschaften (anzahl, Leistungsaufnahme, Lagermaße, Lagergewicht, ..., Wartungszyklus, Bild)
 * Kategorie
 * Kategorien erweiterbar
 * Kategorien löschbar
 * Aktueller lagerort
 * Verleihistorie (nachverfolgung von schäden)
 * Wartung fällig
 * Anschaffungskosten
 * Verleihkosten
 * Anzahl der Buchungen
 * Armortisierung (Gerät abbezahlt)
 * Armortisierung speichern. Änderungen der Verleikosten darf den Wert nicht ändern, Einkaufspreis aber schon
 * (Note: Armortisierung aus Historie berechnen)

### Angebot
 * Peris (Netto, Brutto, Rabatt)
 * Mitarbeiter (Lohnkosten)
 * Fahrkosten
 * Veranstaltungskosten
 * Kunde
 * Datum
 * Dauer
 * Ort
 * Verfasser des Angebotes
 * Materialliste
 * Fotos des Versendeten Materials

### Rechnung
 * Wird nach event erzeugt
 * Mitarbeiter (Lohnkosten)
 * Fahrkosten
 * Verwaltungskosten
 * Verfasser des Angebotes
 * Rechnungsfrist
 * Rechnungsnummer
 * kontodaten des Unternehmens
 * Kunde / Veranstallter
 * Datum
 * Dauer
 * Ort

#### Übersicht
  * Über bezahlte / nicht bezahlte Rechnungen
  * Errinerug an nicht bezahlte Rechnungen ber E-Mail (30 Tage)
  * Generierung einer Mahnung mit mahngebüren und einem Neuen Zahlungsdatum


### Event
 * Veranstalter 
 * Diensleister
 * Veranstalter kann resourcen für das event buchen
 * Start / End Datum
 * Budget / Budget spielraum
 * Off-Days für Resources
 * Off-Days werden rabatiert
 * Off-Days nachträglich änderbar
 * Preis für Resourcen (nur On-Days)
 * Eine Veranstaltung kann zu einem Event Konvertiert werden.
 


## Endgeräte 
 * Smartphone
 * Desktop (webbrowser)
 * Browser: (Chrome, Edge, Firefox, Safari)
 * Sprachassistenten
 * Web und App müssen Konsistent sein
  
## Zielgruppe
 * Privatleute
 * Firmen
 * Schulen (Klassenfahrt)
  
## Various
 * Verschlüsselte Kommunikation (https)
 * Intuitive Bedienung (ohne große einarbeitung)
 * Client Server System
 * "sehr Performant"
 * Einhalten der DSGVO (Sehr vertrauliche Informationen)
   + Daten exportieren
   + Löschen
   + Aufbewahrungsfristen?
   + Einwilligungs-Logging
 * Sensieble daten sollen nut verschlüsselt unter Nutzern ausgetausch werden
 * end to end verschlüsselung?
 * Authentifikation
   + Ermutigung zu starken Passwörtern
   + 2-Faktor authentifizierung
   + Session-Timeouts
   
