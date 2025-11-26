import pandas as pd
# a)
index = pd.date_range("2025-12-24", "2026-1-6", freq="B")
print(index)
print("Es gibt " + str(len(index)) + " normale Wochentage/reguläre Arbeitstage in den Weihnachtsferien 2025/26.")
print("")
# b)
index2 = pd.date_range("2025-12-24", "2027-01-06")
index2 = index2[(index2.day == 1) & (index2.weekday == 6)]
print(index2)
print("Vom 24.12.2025 bis zum 6.01.2027 gibt es " + str(len(index2)) + " Sonntage, die auf den 1. des Monats fallen.")