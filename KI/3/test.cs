#:package GeneticSharp@3.1.4


using System.Collections;
using GeneticSharp;

Console.WriteLine("Hello world");



class Chromosome : IChromosome
{
    public int Length => throw new NotImplementedException();

    public double? Fitness { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public IChromosome Clone()
    {
        throw new NotImplementedException();
    }

    public int CompareTo(IChromosome? other)
    {
        throw new NotImplementedException();
    }

    public IChromosome CreateNew()
    {
        throw new NotImplementedException();
    }

    public Gene GenerateGene(int geneIndex)
    {
        throw new NotImplementedException();
    }

    public Gene GetGene(int index)
    {
        throw new NotImplementedException();
    }

    public Gene[] GetGenes()
    {
        throw new NotImplementedException();
    }

    public void ReplaceGene(int index, Gene gene)
    {
        throw new NotImplementedException();
    }

    public void ReplaceGenes(int startIndex, Gene[] genes)
    {
        throw new NotImplementedException();
    }

    public void Resize(int newLength)
    {
        throw new NotImplementedException();
    }
}

var ga = new GeneticAlgorithm();

ga.GenerationRan += (s, e) => { };


class RandomNumberMutation : MutationBase
{
    protected override void PerformMutate(IChromosome chromosome, float probability)
    {
        throw new NotImplementedException();
    }
}

RankSelection