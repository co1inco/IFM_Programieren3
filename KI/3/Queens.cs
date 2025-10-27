#:package GeneticSharp@3.1.4

using System.Collections;
using System.Globalization;
using System.Runtime.ExceptionServices;
using GeneticSharp;



// var selection = new RankSelection();
var selection = new EliteSelection();
var crossover = new TwoPointCrossover();
var mutation = new DisplacementMutation();
var fitness = new FuncFitness(x => x.Fitness ?? 0);
var population = new Population(10, 40, new QueensChromosom(5));
var termination = new OrTermination(
    new FitnessThresholdTermination(100),
    new GenerationNumberTermination(200_000));
// var termination = new FitnessStagnationTermination();
// var termination = new GenerationNumberTermination(2000);

var ga = new GeneticAlgorithm(population, fitness, selection, crossover, mutation)
{
    Termination = termination
};


var oldBest = 100000.0;
ga.GenerationRan += delegate
{
    // DrawSampleName(selectedSampleName);
    var bestChromosome = ga.Population.BestChromosome;
    if (oldBest == bestChromosome.Fitness)
        return;
    oldBest = bestChromosome.Fitness ?? 0;

    // Console.WriteLine("Termination: {0}", termination);
    Console.WriteLine("Generations: {0}", ga.Population.GenerationsNumber);
    Console.WriteLine("Fitness: {0,10}", bestChromosome.Fitness);
    // Console.WriteLine("Time: {0}", ga.TimeEvolving);
    // Console.WriteLine("Speed (gen/sec): {0:0.0000}", ga.Population.GenerationsNumber / ga.TimeEvolving.TotalSeconds);
    Console.WriteLine($"Conflicts: {((QueensChromosom)bestChromosome).CalculateFitness()}");
};
ga.TerminationReached += (_, _) =>
{
    Console.WriteLine("Terminate");
};

ga.Start();
Console.WriteLine($"R: {ga.IsRunning}");

var final = ga.Population.BestChromosome;
Console.WriteLine("Generations: {0}", ga.Population.GenerationsNumber);
Console.WriteLine("Fitness: {0,10}", final.Fitness);
((QueensChromosom)final).DrawBoard();


class QueensChromosom : IChromosome
{
    private bool[][] _map;
    private readonly int _queens;

    public QueensChromosom(int queens)
    {
        _queens = queens;
        _map = Enumerable.Range(0, queens)
        .Select(_ =>
            Enumerable.Range(0, queens).Select(_ => false).ToArray())
        .ToArray();

        for (int i = 0; i < _queens; i++)
        {
            var j = Random.Shared.Next(_queens);
            _map[i][j] = true;
        }
    }

    public double? Fitness
    {
        get => CalculateFitness() * -1 + 100;
        set => throw new NotImplementedException();
    }

    public int CalculateFitness()
    {
        var fit = 0;
        for (int i = 0; i < _queens; i++)
        {
            for (int j = 0; j < _queens; j++)
            {
                if (_map[i][j])
                {
                    for (var k = 1; k < _queens - i; k++)
                    {
                        if (_map[i + k][j])
                            fit++;
                        if (j - k >= 0 && _map[i + k][j - k])
                            fit++;
                        if (j + k < _queens && _map[i + k][j + k])
                            fit++;
                    }
                }
            }
        }
        return fit;
    }

    public int Length => _queens;

    public IChromosome Clone()
    {
        return new QueensChromosom(_queens)
        {
            _map = _map.Select(x => x.ToArray()).ToArray()
        };
    }

    public int CompareTo(IChromosome? other)
    {
        // does it maybe not use the fitness but the CompareTo function to compare chromosomes
        if (other is null)
            return 1;

        // if (Fitness < other.Fitness)
        //     return 1;
        // if (Fitness > other.Fitness)
        //     return -1;
        if (Fitness > other.Fitness)
            return 1;
        if (Fitness < other.Fitness)
            return -1;
        return 0;
    }

    public IChromosome CreateNew()
    {
        return new QueensChromosom(_queens);
    }

    public Gene GenerateGene(int geneIndex)
    {
        return new Gene(_map[geneIndex]);
    }

    public Gene GetGene(int index)
    {
        return new Gene(_map[index]);
    }

    public Gene[] GetGenes()
    {
        return _map.Select(x => new Gene(x)).ToArray();
    }

    public void ReplaceGene(int index, Gene gene)
    {
        _map[index] = (bool[])gene.Value;
    }

    public void ReplaceGenes(int startIndex, Gene[] genes)
    {
        for (int i = 0; i < genes.Length; i++)
            ReplaceGene(startIndex + i, genes[i]);
    }

    public void Resize(int newLength)
    {
        throw new NotImplementedException();
    }

    public void DrawBoard()
    {
        foreach (var r in _map)
        {
            foreach (var c in r)
            {
                if (c)
                    Console.Write("[x]");
                else
                    Console.Write("[ ]");
            }
            Console.WriteLine();
        }
    }
}


