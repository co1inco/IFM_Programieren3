import pandas as pd
population = pd.read_csv("countries_population.csv", sep=" ", thousands=",", quotechar="'", index_col=0, names=["Country", "Population"])
print(population.head())