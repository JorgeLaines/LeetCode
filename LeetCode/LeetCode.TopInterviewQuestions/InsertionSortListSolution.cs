namespace LeetCode.TopInterviewQuestions
{
    public class InsertionSortListSolution
    {
        public class ListNode
        {
            public int val;

            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public ListNode ConvertArrayToListNode(int[] array)
        {
            ListNode previous = null, root = null;
            for (int i = 0; i < array.Length; i++)
            {
                if(root == null)
                {
                    previous = new ListNode(array[i]);
                    root = previous;
                }
                else
                {
                    previous.next = new ListNode(array[i]);
                    previous = previous.next;
                }
            }
            return root;
        }

        public int[] ConvertListNodeToArray(ListNode head, int sizeArray)
        {
            var result = new int[sizeArray];
            int counter = 0;
            var next = head; 
            while(next != null) 
            {
                result[counter] = next.val;
                next = next.next;
                counter++;
            }
            return result;
        }

        public ListNode InsertionSortList(ListNode head)
        {
            ListNode mainCursor, itemCursor, root, item;
            mainCursor = head;
            itemCursor = mainCursor;
            root = mainCursor;

            while (mainCursor.next != null)
            {
                if(mainCursor.next.val < mainCursor.val)
                {
                    item = mainCursor.next;
                    mainCursor.next = mainCursor.next.next;
                    if(item.val <= root.val)
                    {
                        item.next = root;
                        root = item;
                    }
                    else
                    {
                        itemCursor = root;
                        while (itemCursor.next != null && itemCursor.next.val < item.val)
                        {
                            itemCursor = itemCursor.next;
                        }
                        item.next = itemCursor.next;
                        itemCursor.next = item;
                    }
                }
            }
            return root;
        }
    }
}
