﻿// Copyright (c) Yan Cui 2012

// Email : theburningmonk@gmail.com
// Blog  : http://theburningmonk.com

namespace DynamoDb.SQL.Execution

open System.Runtime.CompilerServices
open System.Collections.Generic
open System.Threading.Tasks
open Amazon.DynamoDB
open Amazon.DynamoDB.Model
open DynamoDb.SQL.Ast

[<AutoOpen>]
module LowLevel =
    /// Active pattern for getting the query or scan request object
    val (|IsQueryReq|IsScanReq|) : DynamoQuery -> Choice<QueryRequest, ScanRequest>

/// Extension methods for the low level DynamoDB client
[<Extension>]
[<AbstractClass>]
[<Sealed>]
type AmazonDynamoDBClientExt =
    /// Executes a query asynchronously and returns the results
    [<Extension>]
    static member QueryAsync       : AmazonDynamoDBClient * string -> Async<QueryResponse>

    /// Executes a query asynchronously as a task and returns the results
    [<Extension>]
    static member QueryAsyncAsTask : AmazonDynamoDBClient * string -> Task<QueryResponse>

    /// Executes a query synchronously and returns the results
    [<Extension>]
    static member Query            : AmazonDynamoDBClient * string -> QueryResponse

    /// Executes a scan asynchronously and returns the results
    [<Extension>]
    static member ScanAsync        : AmazonDynamoDBClient * string -> Async<ScanResponse>

    /// Executes a scan asynchronously as a task and returns the results
    [<Extension>]
    static member ScanAsyncAsTask  : AmazonDynamoDBClient * string -> Task<ScanResponse>

    /// Executes a scan synchronously and returns the results
    [<Extension>]
    static member Scan             : AmazonDynamoDBClient * string -> ScanResponse