import Foundation

public func calculateFibAt(_ n: Int) -> Int {
    if n < 2 {
        return n
    } else {
        return calculateFibAt(n-2) + calculateFibAt(n-1)
    }
}

public func fibFaster(_ n: Int) -> [Int] {
    var sequence: [Int] = [0,1]
    
    for i in 2...n {
        sequence.append(sequence[i-2] + sequence[i-1])
    }
    
    return sequence
}

public func sieve(_ n: Int) -> [Int] {
    var list = [Bool]()
    
    // load the list, defaulting to "true" as unmarked
    for _ in 0 ..< n {
        list.append(true)
    }
    
    // figure out our multiplier limit
    let limit = Int(sqrt(Double(n)))
    
    // run over the list, starting at 2
    for i in 2 ..< limit {
        for x in stride(from: i + i, to: n, by: i) {
            // set all multiples of i to false
            list[x] = false
        }
    }
    
    // build an output array
    var out = [Int]()
    for i in 2 ..< n {
        // if the list value is true, push the index
        if list[i] {
            out.append(i)
        }
    }
    
    return out
}

public func sieveTwo(_ n: Int) -> [Int] {
    var list = [(Int, Bool)]()
    
    // load the list, defaulting to "true" as unmarked
    for i in 0 ..< n {
        list.append((i, true))
    }
    
    // figure out our multiplier limit
    let limit = Int(sqrt(Double(n)))
    
    func checkMultiples (_ i: Int, _ list: [(index: Int, value: Bool)]) -> [(Int,Bool)] {
        var newList = [(Int, Bool)]()
        guard var head = list.first else {
            return newList
        }
        
        // is it eligible?
        if (head.index > i && head.value) {
            
            // is it a multiple of i?
            if head.index % i == 0 {
                head.value = false
            }
        }
        newList.append(head)
        newList.append(contentsOf: checkMultiples(i, Array(list.dropFirst())))
        
        return newList
        
    }
    for i in 2 ... limit {
        list = checkMultiples(i, list)
    }
    
    // build an output
    func buildOutput(_ input: [(index: Int, value: Bool)]) -> [Int] {
        var out = [Int]()
        
        guard let head = input.first else {
            return out
        }
        
        if head.value {
            out.append(head.index)
        }
        out.append(contentsOf: buildOutput(Array(input.dropFirst())))
        
        return out
    }
    
    return buildOutput(list)
}

public func bellmanFord() {
    var vertices = ["S", "A", "B", "C", "D", "E"]
    
    var memo = [
        "S": 0,
        "A": Int.max,
        "B": Int.max,
        "C": Int.max,
        "D": Int.max,
        "E": Int.max
    ]
    
    let graph: [(from: String, to: String, cost: Int)] = [
        ("S", "A", 4),
        ("S", "E", -5),
        ("A", "C", 6),
        ("B", "A", 3),
        ("C", "B", -2),
        ("D", "C", 3),
        ("D", "A", 10),
        ("E", "D", 8)
    ]
    
    // represents a full iteration of Bellman-Ford on our graph
    func iterate() {
        
        // check each vertex
        for i in 0..<vertices.count {
            
            // get the reference vertex
            let fromVertex = vertices[i]
            
            // get the outgoing edges for this vertex
            let edges = graph.filter { $0.from == fromVertex }
            
            edges.forEach { edge in
                
                // the cost of the edge under evaluation
                let edgeCost = edge.cost
                
                // the existing cost of the current vertex from S
                let currentVertexCost = memo[edge.from]!
                
                // the proposed cost from S to the current vertex
                if currentVertexCost == Int.max {
                    return
                }
                let potentialCost = currentVertexCost + edgeCost
                
                // if it's less, update the memo table
                if potentialCost < memo[edge.to]! {
                    memo[edge.to] = potentialCost
                }
            }
        }
    }
    
    for _ in 0 ..< vertices.count - 1 {
        iterate()
    }
    
    print(memo)
}


public func dykstra() {
    typealias MemoEntry = (name: String, cost: Int, visited: Bool)
    
    var vertices = ["S", "A", "B", "C", "D", "E"]
    
    // our memoization table, which I'll set to an object
    // defaulting as described
    struct MemoTable {
        
        // the internal representation of our memoization table
        var table: [MemoEntry] = [
            ("S", 0, false),
            ("A", Int.max, false),
            ("B", Int.max, false),
            ("C", Int.max, false),
            ("D", Int.max, false),
            ("E", Int.max, false)
        ]
        
        // returns all unvisited vertices
        func getCandidateVertices() -> [MemoEntry] {
            return table.filter { $0.visited == false }
        }
        
        // returns the entry for vertex S
        func source() -> MemoEntry {
            return getEntry("S")
        }
        
        // return a single entry in our table
        func getEntry(_ vertex: String) -> MemoEntry {
            return table.filter { $0.name == vertex }.first!
        }
        
        // returns the next unvisited vertex with the least cost
        func nextVertex() -> MemoEntry? {
            let candidates = getCandidateVertices()
            // return the lowest
            if candidates.count > 0 {
                return candidates.reduce(candidates[0]) { (prev, curr) -> MemoEntry in
                    return prev.cost < curr.cost ? prev : curr
                }
            } else {
                return nil
            }
        }
        
        // sets the cost of a given vertex in our table
        mutating func setCurrentCost(_ vertex: String, _ cost: Int) {
            table = table.map({ entry in
                if entry.name == vertex {
                    return (name: entry.name, cost: cost, visited: entry.visited)
                } else {
                    return entry
                }
            })
        }
        
        // marks the vertex as visited
        mutating func setAsVisited(_ vertex: String) {
            table = table.map({ entry in
                if entry.name == vertex {
                    return (name: entry.name, cost: entry.cost, visited: true)
                } else {
                    return entry
                }
            })
        }
        
        // returns the cost associated with reaching
        // a given vertex from the source
        func getCost(_ vertex: String) -> Int {
            return table.filter { $0.name == vertex }.first!.cost
        }
        
        // for display purposes
        func toString() {
            print(table)
        }
    }
    
    let graph: [(from: String, to: String, cost: Int)] = [
        ("S", "A", 4),
        ("S", "E", 2),
        ("A", "D", 3),
        ("A", "C", 6),
        ("A", "B", 5),
        ("B", "A", 3),
        ("C", "B", 1),
        ("D", "C", 3),
        ("D", "A", 1),
        ("E", "D", 1)
    ]
    
    var memo = MemoTable()
    
    func evaluate(_ vertex: MemoEntry) {
        
        // get the outgoing edges for this vertex
        let edges = graph.filter { $0.from == vertex.name }
        
        // iterate over the edges and set the costs
        edges.forEach { edge in
            
            // the cost of the edge under evaluation
            let edgeCost = edge.cost
            
            let currentVertexCost = memo.getCost(edge.from)
            let toVertexCost = memo.getCost(edge.to)
            
            if currentVertexCost == Int.max {
                return
            }
            // the proposed cost from S to the current vertex
            let tentativeCost = currentVertexCost + edgeCost
            
            // if ti's less, update the memo table
            if tentativeCost < toVertexCost {
                memo.setCurrentCost(edge.to, tentativeCost)
            }
        }
        
        // this vertex has been visited
        memo.setAsVisited(vertex.name)
        
        // get the next vertex
        let next = memo.nextVertex()
        
        if next != nil {
            evaluate(next!)
        }
    }
    
    evaluate(memo.source())
    memo.toString()
}
