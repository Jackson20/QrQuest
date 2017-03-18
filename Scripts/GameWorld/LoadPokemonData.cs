using UnityEngine;
using System.Collections;
using System.Xml.Linq;
using System.Collections.Generic;
using System;

public class LoadPokemonData : MonoBehaviour
{
    public string URL;
    public GameObject ModelPrefabs;
    public List<Model> Models { get; set; }
    //public List<PokemonHelper> PokemonHelpers { get; set; }

    private string m_xml = "";

    IEnumerator Start()
    {
        //PokemonHelpers = new List<PokemonHelper>();

        while (!GPS.gpsFix)
        {
            yield return null;
        }

        WWW www = new WWW(URL);
        while (!www.isDone)
        {
            yield return null;
        }

        Debug.Log(www.text);
        m_xml = www.text;

        XDocument doc = XDocument.Parse(m_xml);
        XElement element = doc.Element("models");
        IEnumerable<XElement> elements = element.Elements();

        // Parsing
        Models = new List<Model>();

        foreach (XElement item in elements)
        {
            Model newModel = new Model();
            newModel.ID = System.Convert.ToInt32(item.Attribute("id").Value);
            newModel.lat = System.Convert.ToSingle(item.Attribute("lat").Value);
            newModel.lon = System.Convert.ToSingle(item.Attribute("lon").Value);

            Models.Add(newModel);
        }

        Debug.Log("Models.Count = " + Models.Count);

        // Instantiating
        foreach (var item in Models)
        {
            GameObject model = Instantiate(ModelPrefabs);

            SetGPSdata setGPSdata = model.GetComponent<SetGPSdata>();
            setGPSdata.SetLocation(item.lat, item.lon);

            ModelGameplay modelGameplay = model.GetComponent<ModelGameplay>();
            modelGameplay.LoadModel(item);

           // PokemonHelpers.Add(pokemonHelper);
        }
    }
}
