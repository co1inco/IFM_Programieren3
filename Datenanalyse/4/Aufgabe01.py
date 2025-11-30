import pandas as pd
import matplotlib.pyplot as plt
from sklearn.datasets import load_iris

# Datensatz laden
iris = load_iris()
df = pd.DataFrame(iris.data, columns=iris.feature_names)
df['species'] = pd.Categorical.from_codes(iris.target, iris.target_names)
print(df)

# Farben für jede Klasse
colors = {'setosa': 'blue', 'versicolor': 'red', 'virginica': 'green'}

# Layouten
fig, axes = plt.subplots(2, 2, figsize=(15, 8))
# 2D zu 1D Array konvertieren für einfachere Datenverarbeitung
axes = axes.ravel()

# Durch jedes Feature iterieren und ein Histogramm dafür zeichnen
for idx, feature in enumerate(iris.feature_names):
    ax = axes[idx]
    for species in df['species'].unique():
        subset = df[df['species'] == species]
        ax.hist(subset[feature], 
                bins=10, 
                label=species, 
                color=colors[species])
    ax.set_xlabel(feature)
    ax.legend()

plt.tight_layout()
plt.show()
