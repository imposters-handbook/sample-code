public func binarySearch(list: [Int], lookFor: Int) -> Int {
    var min = 0
    var max = list.count - 1
    var middle = 0
    
    while min <= max {
        // find the middle of the list
        middle = (min + max) / 2
        
        // if we just happen to land on it…
        if list[middle] == lookFor {
            return middle
        } else {
            // the list is sorted, so if we're looking too low…
            if list[middle] < lookFor {
                // increase the minimum
                min = middle + 1
            } else {
                // decrease the max
                max = middle - 1
            }
        }
    }
    
    return -1
}
