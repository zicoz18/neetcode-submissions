public class TimeMap {
    struct ValueWithTime {
        public string value;
        public int time;
    }
    Dictionary<string, List<ValueWithTime>> map;

    public TimeMap() {
        map = new Dictionary<string, List<ValueWithTime>>();
    }
    
    public void Set(string key, string value, int timestamp) {
        if (map.TryGetValue(key, out List<ValueWithTime> listOfValues)) {
            listOfValues.Add(new ValueWithTime{value = value, time = timestamp});
        } else {
            List<ValueWithTime> list = new List<ValueWithTime>();
            list.Add(new ValueWithTime{value = value, time = timestamp});
            map[key] = list;
        }
    }
    
    public string Get(string key, int timestamp) {
        if (map.TryGetValue(key, out List<ValueWithTime> listOfValues)) {
            int leftPointer = 0;
            int rightPointer = listOfValues.Count - 1;
            int midPointer = (leftPointer + rightPointer) / 2;
            if (listOfValues[leftPointer].time > timestamp) {
                return "";
            } 
            while (leftPointer <= rightPointer) {
                midPointer = (leftPointer + rightPointer) / 2;
                ValueWithTime mid = listOfValues[midPointer];
                if (mid.time == timestamp) return mid.value;
                if (leftPointer == rightPointer) {
                    // Its not in the list and we should return the value smaller than the searched
                    if (midPointer > 0) {
                        int midTime = listOfValues[midPointer].time;
                        if (midTime > timestamp) {
                            return listOfValues[midPointer - 1].value;
                        } else {
                            return listOfValues[midPointer].value;
                        }
                    } else {
                        return listOfValues[leftPointer].value;
                    }
                } 
                else if (mid.time < timestamp) {
                    leftPointer = midPointer + 1;
                } else {
                    rightPointer = midPointer - 1;
                }
            }
            if (midPointer > 0) {
                int midTime = listOfValues[midPointer].time;
                if (midTime > timestamp) {
                    return listOfValues[midPointer - 1].value;
                } else {
                    return listOfValues[midPointer].value;
                }
            } else {
                return listOfValues[leftPointer].value;
            }
        } else {
            return "";
        }
    }
}
