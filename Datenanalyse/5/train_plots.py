# Visualisierung: erste 200 Zeilen als Zeitreihe (normierte Werte)
plt.figure(figsize=(14,6))
for col in train_scaled.columns:
    plt.plot(train_scaled.index[:200], train_scaled[col].iloc[:200], label=col, linewidth=1)
plt.xlabel('Index')
plt.ylabel('Normierter Wert (0-1)')
plt.title('Train (normiert) — erste 200 Zeilen')
plt.legend(bbox_to_anchor=(1.05,1), loc='upper left')
plt.tight_layout()
plt.show()

# Histogramme der normierten Spalten (Train)
train_scaled.hist(bins=20, figsize=(12,8))
plt.suptitle('Histogramme der normierten Trainingsspalten')
plt.tight_layout()
plt.show()

# Scattermatrix auf einem Subset (Train)
from pandas.plotting import scatter_matrix
subset = train_scaled.iloc[:200]
scatter_matrix(subset, figsize=(12,12), diagonal='kde', alpha=0.6)
plt.suptitle('Scattermatrix (Train normiert, erste 200)')
plt.tight_layout()
plt.show()