
//define the vertices - these can just be string values
var vertices = ["S","A", "B", "C", "D", "E"];

//our memoization table, which I'll set to an object
//defaulting as described
var memo = {
  S : 0,
  A : Number.POSITIVE_INFINITY,
  B : Number.POSITIVE_INFINITY,
  C : Number.POSITIVE_INFINITY,
  D : Number.POSITIVE_INFINITY,
  E : Number.POSITIVE_INFINITY
}

//this is our graph, relationships between vertices
//with costs associated
var graph = [
  {from : "S", to : "A", cost: 4},
  {from : "S", to :"E", cost: 6},
  {from : "A", to :"C", cost: 6},
  {from : "B", to :"A", cost: 3},
  {from : "C", to :"B", cost: 2},
  {from : "D", to :"C", cost: 3},
  {from : "D", to :"A", cost: 10},
  {from : "E", to: "D", cost: 8}
];

//represents a full iteration of Bellman-Ford on our graph
var iterate = function(){

  //check each vertex
  for(var i = 0; i < vertices.length; i++){

    //get the reference vertex
    var fromVertex = vertices[i];

    //get the outgoing edges for this vertex
    var edges = graph.filter(function(path){
      return path.from === fromVertex;
    });

    //iterate over the edges and set the costs
    edges.forEach(function(edge){

      //the cost of the edge under evaluation
      var edgeCost = edge.cost;

      //the existing cost of the current vertex from S
      var currentVertexCost = memo[edge.from];

      //the proposed cost from S to the current vertex
      var potentialCost = currentVertexCost + edgeCost;

      //if it's less, update the memo table
      if(potentialCost < memo[edge.to]){
        memo[edge.to] = potentialCost;
      }
    });
  };
};

for(var i = 0; i < vertices.length -1; i++){
  iterate();
}
console.log(memo);
