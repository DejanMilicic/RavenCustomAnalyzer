# RavenCustomAnalyzer

## What is this?

A sample project that demonstrates
- usage of Custom Analyzer
- full text search that takes various languages into account

## Before you can run it

1. Start RavenDB
2. Crate "articles" database 

## When you run it
1. Search index will be created
2. Three articles in French, English and unspecified language will be created

- Articles with empty language property will be treated as English text
- Search index will apply StandardAnaluzer for English and FrenchAnalyzer for French text
- Program.cs has an example on how to treat fields separately, but also how to treat search field in a generic manner
