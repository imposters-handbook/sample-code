
//our memoization table, which I'll set to an object
//defaulting as described
var MemoTable = function(){
  //the internal representation of our memoization table
  var table = [
    {name: "S", cost: 0, visited: false},
    {name: "A", cost: Number.POSITIVE_INFINITY, visited: false},
    {name: "B", cost: Number.POSITIVE_INFINITY, visited: false},
    {name: "C", cost: Number.POSITIVE_INFINITY, visited: false},
    {name: "D", cost: Number.POSITIVE_INFINITY, visited: false},
    {name: "E", cost: Number.POSITIVE_INFINITY, visited: false}
  ];

  //returns all unvisited vertices
  var getCandidateVertices = function(){
    return table.filter(function(entry){
      return entry.visited === false;
    });
  };

  //returns the entry for vertex S
  this.source = function(){
    return this.getEntry("S");
  }

  //returns the next unvisited vertex with least cost
  this.nextVertex = function(){
    var candidates = getCandidateVertices();

    //return the lowest
    if(candidates.length > 0){
      return candidates.reduce(function(prev, curr){
        return prev.cost < curr.cost ? prev : curr;
      });
    }else{
      return null;
    }
  };

  //sets the cost of a given vertex in our table
  this.setCurrentCost = function(vertex, cost){
    var entry = this.getEntry(vertex);
    //set the cost
    entry.cost = cost;
  };

  //marks the vertex as visited
  this.setAsVisited = function(vertex){
    var entry = this.getEntry(vertex);
    //mark the vertex as visited
    entry.visited = true;
  }

  //returns a single entry in our table
  this.getEntry = function(vertex){
    return table.filter(function(entry){
      return entry.name === vertex;
    })[0];
  }

  //returns the cost associated with reaching
  //a given vertex from the source
  this.getCost = function(vertex){
    return this.getEntry(vertex).cost;
  }

  //for display purposes
  this.toString = function(){
    console.log(table);
  }

}
var memo = new MemoTable();

//this is our graph, relationships between vertices
//with costs associated
var graph = [
  {from : "S", to :"A", cost: 4},
  {from : "S", to :"E", cost: 2},
  {from : "A", to :"D", cost: 3},
  {from : "A", to :"C", cost: 6},
  {from : "A", to :"B", cost: 5},
  {from : "B", to :"A", cost: 3},
  {from : "C", to :"B", cost: 1},
  {from : "D", to :"C", cost: 3},
  {from : "D", to :"A", cost: 1},
  {from : "E", to: "D", cost: 1}
];

var evaluate = function(vertex){

  //get the outgoing edges for this vertex
  var edges = graph.filter(function(path){
    return path.from === vertex.name;
  });

  //iterate over the edges and set the costs
  edges.forEach(function(edge){
    //the cost of the edge under evaluation
    var edgeCost = edge.cost;

    var currentVertexCost = memo.getCost(edge.from);
    var toVertexCost = memo.getCost(edge.to);

    //the proposed cost from S to the current vertex
    var tentativeCost = currentVertexCost + edgeCost;

    //if it's less, update the memo table
    if(tentativeCost < toVertexCost){
      memo.setCurrentCost(edge.to, tentativeCost);
    }
  });

  //this vertex has been visited
  memo.setAsVisited(vertex.name);

  //get the next vertex
  var next = memo.nextVertex();

  //recurse
  if(next) evaluate(next);
}

//kick it off!
evaluate(memo.source());
memo.toString();
