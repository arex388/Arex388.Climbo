# BENCHMARKS



### .NET 7

#### ClimboClientFactory

| Method               |     Mean |   Error |  StdDev |   Gen0 | Allocated |
| -------------------- | -------: | ------: | ------: | -----: | --------: |
| CreateAndCacheClient | 238.4 ns | 0.64 ns | 0.60 ns | 0.0324 |     136 B |

#### ReviewInvitation

| Method      |     Mean |    Error |   StdDev | Allocated |
| ----------- | -------: | -------: | -------: | --------: |
| GetAsync    | 394.5 ms | 19.75 ms | 18.47 ms |  15.84 KB |
| DeleteAsync | 388.7 ms |  7.72 ms |  6.84 ms |  14.85 KB |
| PutAsync    | 201.5 ms |  3.78 ms |  3.15 ms |   8.96 KB |

#### ReviewStatistics

| Method   |     Mean |   Error |  StdDev | Allocated |
| -------- | -------: | ------: | ------: | --------: |
| GetAsync | 179.9 ms | 2.55 ms | 2.26 ms |    5.5 KB |
