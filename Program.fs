open System
open System.Collections.Generic
open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running


[<MemoryDiagnoser>]
type Benchmarks () =

    let testFunction x =
        x + 1

    let myTestData =
        [|0 .. 10000|]

    let myLocalData =
        [|0 .. 10000|]


    let rng = Random 123
    let dataCount = 100
    let sampleCount = 10
    let loopCount = 10_000
    let randoData =
        [| for _ in 1 .. dataCount do
            rng.Next 100
        |]

    let randomIndexGenerator = Random 42
    let randomIndices =
        [| for _ in 1 .. sampleCount do
            randomIndexGenerator.Next randoData.Length
        |]

    

    // Lesson 0 : Trust, but verify!!

    // Leasson 1 : Have data inside the Benchmarks class

    [<Benchmark>]
    member _.OuterData () =
        myTestData
        |> Array.map testFunction

    [<Benchmark>]
    member _.InnterData () =
        myLocalData
        |> Array.map testFunction

    // Lesson 2: Prefer pre-computed data

    [<Benchmark>]
    member _.GenerateIndex () =
        let mutable acc = 0
        let otherRandomIndexGenerator = Random 42

        for i = 1 to sampleCount do 
            let randomIndex = otherRandomIndexGenerator.Next randoData.Length
            // Some other work here...
            acc <- acc + randoData[randomIndex]

        acc

    [<Benchmark>]
    member _.PrecomputeIndex () =
        let mutable acc = 0

        for i = 0 to sampleCount - 1 do 
            let randomIndex = randomIndices[i]
            // Some other work here...
            acc <- acc + randoData[randomIndex]

        acc

    // Lesson 3: Refer to Lesson 0

    [<Benchmark>]
    member _.IndexForLoop () =
        let mutable acc = 0

        for i = 0 to randomIndices.Length - 1 do 
            let randomIndex = randomIndices[i]
            // Some other work here...
            acc <- acc + randoData[randomIndex]

        acc

    [<Benchmark>]
    member _.IndexForEachLoop () =
        let mutable acc = 0

        for i in 0 .. randomIndices.Length - 1 do 
            let randomIndex = randomIndices[i]
            // Some other work here...
            acc <- acc + randoData[randomIndex]

        acc

    [<Benchmark>]
    member _.ForEachLoop () =
        let mutable acc = 0

        for randomIndex in randomIndices do
            // Some other work here...
            acc <- acc + randoData[randomIndex]

        acc


[<EntryPoint>]
let main _ =

    // I don't care about what Run returns so I'm ignoring it
    let _ = BenchmarkRunner.Run<Benchmarks>()
    0
