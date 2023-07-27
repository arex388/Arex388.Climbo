# BENCHMARKS



### .NET 7

#### ClimboClientFactory

| Method               |     Mean |   Error |  StdDev |   Gen0 | Allocated |
| -------------------- | -------: | ------: | ------: | -----: | --------: |
| CreateAndCacheClient | 259.9 ns | 4.88 ns | 4.32 ns | 0.0286 |     120 B |

#### ReviewInvitation

| Method      |     Mean |     Error |    StdDev | Allocated |
| ----------- | -------: | --------: | --------: | --------: |
| GetAsync    | 446.6 ms |  71.31 ms |  82.13 ms |  16.74 KB |
| DeleteAsync | 528.0 ms | 120.75 ms | 139.05 ms |  14.56 KB |
| PutAsync    | 250.5 ms |  40.39 ms |  46.51 ms |   8.89 KB |

#### ReviewStatistics

| Method   |     Mean |    Error |   StdDev |   Median | Allocated |
| -------- | -------: | -------: | -------: | -------: | --------: |
| GetAsync | 209.3 ms | 11.19 ms | 33.00 ms | 197.8 ms |    5.5 KB |
