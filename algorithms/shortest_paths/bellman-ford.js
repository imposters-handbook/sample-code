
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
const iterate = () => {
  //do we need another iteration?
  //decided below
  var doItAgain = false;
  //loop all vertices
  for(fromVertex of vertices){
    //get the outgoing edges
    const edges = graph.filter(path => {
      return path.from === fromVertex;
    });
    //loop the outgoing edges
    for(edge of edges){
      const potentialCost = memo[edge.from] + edge.cost;
      //reset the cost as needed
      if(potentialCost < memo[edge.to]){
        memo[edge.to] = potentialCost;
        //if the cost was changed we need to loop again
        doItAgain = true;
      }
    }
  }
  //return the flag
  return doItAgain;
}
for(vertex of vertices){
  //loop until no changes
  if(!iterate()) break;
}
console.log(memo);
