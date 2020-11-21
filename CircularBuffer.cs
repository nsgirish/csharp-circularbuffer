using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buffering
{
	public class CircularBuffer<T> : IDisposable
	{
		//data members 
		private T[] m_buffer = null; //internal array to store the generic objects
		private int m_index = -1; //index of array
		private int m_capacity = 0; //capacity of array 
		
		//constructor
		//int capacity - total number of objects to be stored in th circular buffer 
		public CircularBuffer(int capacity) 
		{
			m_capacity = capacity;
			m_buffer = new T[m_capacity];
		}
		
		//private function to add a item to circular buffer
		//this function is called inside public function CheckAndAddItem() to add item to circular buffer
		private void AddItem(T item) 
		{
			//reset array index if array has reached its full capacity
			if(m_index +1 >= m_capacity) 
			{
				m_index = -1;
			}
			
			//add object to array 
			m_buffer[++m_index] = item;
			
		}
		
		//function to add items to circular buffer based on a conditinn being satisfied
		//T item - gneeric object to add in buffer
		//Func<T,bool> condition - anonymous function or delegate which checks a condition on whether a item with same attributes is arleady added  
		public bool CheckAndAddItem(T item, Func<T,bool> condition)
		{
			lock(this) 
			{
				if(m_index < 0)
				{
					AddItem(item);
					return true;
				}
				
				//no other item with similar attributes exist in the circular buffer
				if(m_buffer.where(condition).Count() <= 0)
				{
					AddItem(true);
					return true;
				}
				
				//item(s) with similar attributes already exist in circular buffer
				return false;
			}
		}
		
		
	}
}
