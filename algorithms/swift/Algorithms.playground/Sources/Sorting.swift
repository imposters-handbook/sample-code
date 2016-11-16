
public func bubbleSort(_ list: inout [Int]) {
    // a flag to tell us if we need to sort this list again
    var doItAgain = false
    
    // loop variables
    let limit = list.count
    let defaultNextVal = Int.max
    
    // loop over the list entries…
    for i in 0 ..< limit {
        // the current list value
        let thisValue = list[i]
        
        // the next value, which defaults to a really high number
        let nextValue = i + 1 < limit ? list[i + 1] : defaultNextVal
        
        // is the next number lower than the current?
        if nextValue < thisValue {
            // if yes, we switch the values
            list[i] = nextValue
            list[i + 1] = thisValue
            
            // since we made a switch we'll set a flag
            // as we'll need to execute the loop again
            doItAgain = true
        }
    }
    
    // recurse over the list if the flag is set
    if doItAgain {
        bubbleSort(&list)
    }
}


public func mergeSort(_ list: inout [Int]) -> [Int] {
    // if there's only one item in the list, return
    if list.count <= 1 {
        return list
    }
    
    // cut the list in half
    let count = list.count
    let middle = count / 2
    var left = Array(list[0..<middle])
    var right = Array(list[middle..<count])
    
    // recursively run through the splits
    // left and right will be separated down to single elements
    var l = mergeSort(&left)
    print(left)
    var r = mergeSort(&right)
    print(right)
    
    return merge(&l, &r)
}


public func merge(_ left: inout [Int], _ right: inout [Int]) -> [Int] {
    var result = [Int]()
    
    // if the left an right lists both have elements
    // run a comparison
    while !left.isEmpty || !right.isEmpty {
        // if there are items on both sides…
        if !left.isEmpty && !right.isEmpty {
            // if the first item on left
            // is less than on right
            
            if left[0] < right[0] {
                // take the first item on the left
                result.append(left.removeFirst())
            } else {
                // otherwise take the first item
                // on the right
                result.append(right.removeFirst())
            }
        } else if !left.isEmpty {
            result.append(left.removeFirst())
        } else {
            // there are items remaining on the right
            result.append(right.removeFirst())
        }
    }
    
    return result
}


public func quickSort(_ list: inout [Int]) -> [Int] {
    // recursion check. If list is empty or of length 1, return
    if list.count < 2 {
        return list
    }
    
    // these are the partition lists we'll need to use
    var left = [Int]()
    var right = [Int]()
    
    // default the pivor to the last item in the list
    let pivot = list.count - 1
    
    // set the pivot value
    let pivotValue = list[pivot]
    
    // remove the pivot from the list as we don't want to compare it
    list.remove(at: pivot)
    
    // loop the list, comparing the partition values
    for i in 0..<list.count {
        if list[i] < pivotValue {
            left.append(list[i])
        } else {
            right.append(list[i])
        }
    }
    
    // do it all again
    var returnValue = quickSort(&left)
    returnValue.append(pivotValue)
    returnValue.append(contentsOf: quickSort(&right))
    return returnValue
}


public func selectionSort(list: inout [Int]) -> [Int] {
    
    for i in 0..<list.count - 1 {
        // default the min value to the first item in the list
        // all we need do is track the index for now
        var currentMinIndex = i
        
        // loop over the list, skipping the currentMinIndex
        for x in currentMinIndex+1..<list.count {
            
            // if the current list item is less than the current min value…
            if list[x] < list[currentMinIndex] {
                // reset the index
                currentMinIndex = x
            }
        }
        
        // has the index changed?
        if currentMinIndex != i {
            // if yes, switch the values in the list
            let oldMinValue = list[i]
            list[i] = list[currentMinIndex]
            list[currentMinIndex] = oldMinValue
        }
    }
    
    return list
}
