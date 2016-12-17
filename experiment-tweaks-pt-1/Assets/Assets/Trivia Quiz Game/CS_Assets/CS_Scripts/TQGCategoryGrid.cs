//Version 1.65 (10.08.2016)

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using TriviaQuizGame.Types;

namespace TriviaQuizGame
{
	/// <summary>
	/// Includes functions for loading levels and URLs. It's intended for use with UI Buttons
	/// </summary>
	public class TQGCategoryGrid:MonoBehaviour
	{
		// Various objects we cache for quicker access
		internal Transform categoryGridObject;
		internal RectTransform categoryObject;
		internal Transform thisTransform;
		internal GameObject gameController;
		
		[Tooltip("A list of categories, each containing a set of questions for the quiz. You can choose one category at a time")]
		public Category[] categories;
		
		// The current category we have selected
		internal int currentCategory = 0;
		internal GameObject currentCategoryObject;
		
		// General use index
		internal int index;
		internal int[] categoryIndex;
		
		/// <summary>
		/// Start is only called once in the lifetime of the behaviour.
		/// The difference between Awake and Start is that Start is only called if the script instance is enabled.
		/// This allows you to delay any initialization code, until it is really needed.
		/// Awake is always called before any Start functions.
		/// This allows you to order initialization of scripts
		/// </summary>
		void Start()
		{
			thisTransform = transform;
			
			// Hold the gamecontroller for easier access
			if ( GameObject.FindGameObjectWithTag("GameController") )    gameController = GameObject.FindGameObjectWithTag("GameController");
			
			// If we have a category grid, cache the category grid and category object for quicker access
			if ( GameObject.Find("CategoryGrid") )    
			{
				// Hold the category grid
				categoryGridObject = GameObject.Find("CategoryGrid").transform;
				
				// And all the internal parts
				if ( GameObject.Find("CategoryGrid/Category") )    categoryObject = GameObject.Find("CategoryGrid/Category").GetComponent<RectTransform>();
			}
			
			// If we have a category wheel, organize the categories in the wheel
			if ( categoryGridObject && categoryObject )
			{
				//Duplicate the the category object several times to accomodate the number of categories we have
				for ( index = 0 ; index < categories.Length ; index++ )
				{
					// Duplicate the category object
					RectTransform newCategory = Instantiate(categoryObject) as RectTransform;
					
					// Put it inside the category wheel
					newCategory.SetParent(categoryGridObject.transform);
					
					// Set the position and scale of the category to be the same as the default one
					newCategory.sizeDelta = categoryObject.sizeDelta;
					newCategory.position = categoryObject.position;
					newCategory.localScale = categoryObject.localScale;
					
					// Set the text of the slice based on the category name
					newCategory.Find("Text").GetComponent<Text>().text = categories[index].categoryName;
					
					// Hold a reference for this category, for easier access
					categories[index].categoryObject = newCategory.gameObject;
					
					// Set the icon of the category based on the category icon
					newCategory.Find("Icon").GetComponent<Image>().sprite = categories[index].categoryIcon;
					
					// Holds the index number of the category button, which will passed when clicking on the button
					int tempIndex = index;
					
					// Listen for a click to choose the category
					newCategory.GetComponent<Button>().onClick.AddListener(delegate() { SetCategory(tempIndex); });
				}
				
				// Deactivate the original category object
				categoryObject.gameObject.SetActive(false);
			}
		}
		
		
		/// <summary>
		/// Set the current category from the list. Will go through all categories before repeating.
		/// </summary>
		public void SetCategory( int setValue )
		{
			// If we have a category grid
			if ( categoryGridObject ) 
			{
				// Check if the category has a Dynamic XML component
				if ( categories[setValue].GetComponent<TQGDynamicXML>() )
				{
					// Add a Dynamic XML component to the gamecontroller, and copy the info from the one attached to the category
					gameController.AddComponent<TQGDynamicXML>();
					gameController.GetComponent<TQGDynamicXML>().addressType = categories[setValue].GetComponent<TQGDynamicXML>().addressType;
					gameController.GetComponent<TQGDynamicXML>().xmlAddress = categories[setValue].GetComponent<TQGDynamicXML>().xmlAddress;
					
					// Assign the dynamic XML to the variable in the gamecontroller, so that it checks for it when we start the game
					gameController.GetComponent<TQGGameController>().dynamicXML = gameController.GetComponent<TQGDynamicXML>();
				}
				else
				{
					// Set the questions in the quiz based on the currently selected category
					gameController.SendMessage("SetQuestions", categories[setValue].questions);
				}
				
				// Start the game
				gameController.SendMessage("StartGame");
			}
		}
		
		/// <summary>
		/// Set the next category when this screen is activated
		/// </summary>
		void OnEnable()
		{
			SetCategory(currentCategory);
		}
	}
}