#### 3.0.0 - Feb 13 2016
* Moved to AWSSDK v3 (service-specific packages)

#### 2.1.2 - Oct 7 2015
* Fixed issue [#29](https://github.com/theburningmonk/DynamoDb.SQL/issues/29) where long floating point numbers start to lose precision

#### 2.1.1 - Sep 1 2015
* Fixed issue [#28](https://github.com/theburningmonk/DynamoDb.SQL/issues/28) where
  long floating point numbers don't work because they're formatted to scientific
  notation when sent to AWS
  
#### 2.1.0 - May 6 2015
* Allow '.' '_' and '-' in table names

#### 2.0.2 - Oct 4 2014
* Updated `AWSSDK` to `v2.3.1.0`.

#### 2.0.1 - Aug 12 2014
* Updated `AWSSDK` to `v2.2.2.0`.

#### 2.0.0 - Jan 01 2014
* Updated `AWSSDK` to `v2.0.4.1`.
* Replaced exception types with C# friendly types.
* Fixed bug with scanning using specific attributes.
* Verified that Global Secondary Index is supported through existing `Index` option.
* **Breaking Changes**
	* Removed support for the v1 query syntax (i.e. the use of `@HashKey` and `@RangeKey`).
	* The namespace `DynamoDbV2.SQL.Execution` is gone, the extension methods for `AmazonDynamoDBClient` and `DynamoDBContext` are now in their corresponding namespaces so that you don't need to open another namespace to get them	

#### 1.3.1 - July 02 2013
* Updated `AWSSDK` to `v1.5.25.0`.

#### 1.3.0 - June 23 2013
* Support parallel scans with a new optional parameter `Segments`. 

For example:
* `SELECT * FROM Reply WHERE Id >= 900 AND PostedBy BEGINS WITH \"J\" WITH (Segments(15))`

#### 1.2.2 - June 15 2013
* Updated `AWSSDK` to `v1.5.23.2`.

#### 1.2.1 - May 05 2013
* Updated `AWSSDK` to `v1.5.19.0`
* Supports the `AmazonDynamoDBClient` and `DynamoDBContext` under the `Amazon.DynamoDBv2` 
top level namespace introduced in `AWSSDK` `v1.5.19.0` and the new `Local Secondary Index` feature.
* **Query Syntax Change** - when working with the new V2 `AmazonDynamoDBClient` and 
`DynamoDBContext`, the query syntax has changed and the special keywords `@HashKey` and `@RangeKey` 
has been deprecated, and instead you should use the attribute names defined in the table. 
This change is done in alignment with the change in the underlying `AWSSDK` where you no longer 
have to specify Hash and Range key conditions explicitly in a query request.
* **LSI Support** - suppose there's a table called `Reply`, where the Hash key is `ThreadId`, and 
there is an index `PosterIndex` on the `PostedBy` attribute with no projected attributes.
* To query using an index and fetch all attributes:
`SELECT * FROM Reply WHERE ThreadId = 250 AND PostedBy = \"Michael\" WITH(Index(PosterIndex, true))`
* Similarly, to fetch only the attributes in the index:
`SELECT * FROM Reply WHERE ThreadId = 250 AND PostedBy = \"Michael\" WITH(Index(PosterIndex, false))`

#### 1.1.3 - March 27 2013
* Updated `AWSSDK` to `v1.5.16.1`
* Fixed issue [#4](https://github.com/theburningmonk/DynamoDb.SQL/issues/4) where 
`DynamoDbClient` extension methods did not behave correctly with regards to the `Limit` clause.

#### 1.1.2 - March 15 2013
* Updated `AWSSDK` to `v1.5.16.0`.

#### 1.1.1 - March 03 2013
* Updated `AWSSDK` to `v1.5.15.0`.

#### 1.1.0 - February 26 2013
* Added support for `WITH` keyword to allow configurations for page size and eventually 
consistent reads (query only).

For examples:
* Query : `SELECT * FROM PlayerHistory WHERE @HashKey = \"Yan\" WITH (NoConsistentRead, PageSize(10))`
* Scan  : `SELECT * FROM PlayerHistory WHERE FirstName = \"Yan\" WITH (PageSize(10))`

#### 1.0.11 - February 20 2013
* Updated `AWSSDK` to `v1.5.14.0`.

#### 1.0.10 - February 15 2013
* Updated `AWSSDK` to `v1.5.13.0`.

#### 1.0.9 - December 21 2012
* Added F# friendly extension methods.
* Updated `AWSSDK` to `v1.5.9.2`.

#### 1.0.7 - November 24 2012
* Added support for the `Count` keyword for use with the `AmazonDynamoDBClient` type.

For example:
* Query : `COUNT * FROM PlayerHistory WHERE @HashKey = \"Yan\"`
* Scan  : `COUNT * FROM PlayerHistory WHERE FirstName = \"Yan\"`

#### 1.0.6 - November 21 2012
* Fixed bug with `Limit` keyword when there is insufficient number of elements using 
the `DynamoDBContext` type.

#### 1.0.5 - November 20 2012
* Updated `AWSSDK` to `v1.5.8.0`.
* Added support for forward and backward search using optional `Order` keyword.

For example: 
* `SELECT * FROM PlayerHistory WHERE @HashKey = \"Yan\" ORDER DESC`

#### 1.0.0 - November 13 2012
* initial release.