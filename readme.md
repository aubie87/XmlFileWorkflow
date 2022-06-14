## Xml File Workflow Testing

#### Testing Scenarios
1. Sequential file loading and bulk saving.
   - What is the ideal bulk size to save? DB dependent?
2. Sequencial with async file loading and async bulk saving.
  - Don't await DB save until next save is needed. 
  - Could be slightly faster than #1 - is it worth it?
3. Parallel.ForEachAsync file loading and async bulk saving.
   - Parallelize input file processing but otherwise the same as #2.
   - Concern saving to DB from multiple threads.
4. Same as #3 but save objects to a queue and bulk save in 1 dedicated thread.
   - Producer/Consumer queue with many producers and 1 consumer
   - Very possible queue could be overwhelmed with producer data.
   - Consider a [blocking collection](https://docs.microsoft.com/en-us/dotnet/standard/collections/thread-safe/blockingcollection-overview).


#### Questions
- Where should folder and file naming live?
  - app settings or command line - or both?

#### Notes

All database "saves" are done via a "unit of work". The DbContext
goes out of scope at the conclusion of the save operation. 

Once saved, loaded objects should also go "out of scope". Therefore, memory
requirements should remain very tame no mater the size of the input files.

#### Things To Do
- Add command line parsing
  - verbs
    - generate
      - --statement-count (per file, default 1,000)
      - --file-count (default 4)
    - 'process'
      - --run-async
- Implement Options pattern
  - folder and file info?

