using Arex388.Climbo.Benchmarks;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<ClimboClientFactory>();
BenchmarkRunner.Run<ReviewInvitation>();
BenchmarkRunner.Run<ReviewStatistics>();