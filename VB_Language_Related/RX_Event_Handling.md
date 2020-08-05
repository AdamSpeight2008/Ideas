I am proposing that we should extend the capabilities of the VB.net event handling system, by allow use to manipulate events
via the reactive extensions. Especially if we could use the LINQ Query syntax.

The compiler creates a custom delegate that represents the RX query, if the query is a success it raises an event delegate to the original source method. 
