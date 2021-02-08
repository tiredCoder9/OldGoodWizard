using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NameGenerator : MonoBehaviour
{
    public ConstantInteger NameLengthLimit;


    private static ConstantInteger NAME_LENGTH_LIMIT;
    private static int maleNamesCount;
    private static int femaleNamesCount;
    private static int classNamesCount;
    private static int classPostfixesCount;
    private static string namesPath= "NamesCollection";


    private static TextAsset maleNamesAsset;
    private static TextAsset femaleNamesAsset;
    private static TextAsset classNamesAsset;
    private static TextAsset classPostfixesAsset;

    private static string[] maleNames;
    private static string[] femaleNames;
    private static string[] classNames;
    private static string[] classPostfixes;

    private static string maleNamesCollection { get{ return namesPath + "/" + "maleNames"; } }
    private static string femaleNamesCollection { get { return namesPath + "/" + "femaleNames"; } }
    private static string classNamesCollection { get { return namesPath + "/" + "classNames"; } }
    private static string classPostfixesCollection { get { return namesPath + "/" + "classPostfixes"; } }

    private static bool IsCollectionsLoaded=false;

    public void Awake()
    {
        NAME_LENGTH_LIMIT = NameLengthLimit;
    }


    private void LateUpdate()
    {
        if (IsCollectionsLoaded)
        {
            UnloadNamesCollections();
        }
    }

    public static string generate(Character.Gender gender)
    {
        if (!IsCollectionsLoaded) LoadNamesCollections();

        if (NAME_LENGTH_LIMIT == null) return null;
        string name = string.Empty;

        switch (gender)
        {
            case Character.Gender.male:
                name = getRandWord(maleNames);
                break;
            case Character.Gender.female:
                name = getRandWord(femaleNames);
                break;
        }

        if (Randomiser.withChance(50)) 
        {
            string fullName = name + " " + getRandWord(classNames);

            if(fullName.Length < NAME_LENGTH_LIMIT.Value)
            {
                name = fullName;
                if (Randomiser.withChance(50))
                {
                    fullName = name + " " + getRandWord(classPostfixes);
                    if(fullName.Length < NAME_LENGTH_LIMIT.Value)
                    {
                        return fullName;
                    }
                    return name;
                }
            }

            return name;

        }

        return name;
    }

    private static string getRandWord(string[] words)
    {
        return words.getRandomElement<string>().TrimEnd('\r', '\n');

    }

    private static void LoadNamesCollections()
    {
        maleNamesAsset = Resources.Load<TextAsset>(maleNamesCollection);
        
        femaleNamesAsset = Resources.Load<TextAsset>(femaleNamesCollection);
        classNamesAsset = Resources.Load<TextAsset>(classNamesCollection);
        classPostfixesAsset = Resources.Load<TextAsset>(classPostfixesCollection);

        maleNames = getLinesFromResource(maleNamesAsset);   
        femaleNames = getLinesFromResource(femaleNamesAsset);
        classNames = getLinesFromResource(classNamesAsset);
        classPostfixes = getLinesFromResource(classPostfixesAsset);

        IsCollectionsLoaded = true;
    }


    private static void UnloadNamesCollections()
    {
        if (IsCollectionsLoaded)
        {
            maleNames = null;
            femaleNames = null;
            classNames = null;
            classPostfixes = null;

            Resources.UnloadAsset(maleNamesAsset);
         
            Resources.UnloadAsset(femaleNamesAsset);
            Resources.UnloadAsset(classNamesAsset);
            Resources.UnloadAsset(classPostfixesAsset);

            IsCollectionsLoaded = false;
        }
    }

    private static string[] getLinesFromResource(TextAsset textResource)
    {
        return textResource.text.Split('\n');
    }





}
