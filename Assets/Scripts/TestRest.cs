using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;
using Proyecto26;
using SimpleJSON;
using System.Linq;


public class TestRest : MonoBehaviour

{
    // Start is called before the first frame update
    void Start()
    {
      
      Debug.Log("Start!");
        //GETLDH();
        TestValueEmotion();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void Post(){
		
		RestClient.Post<Post>("https://dbpedia.org/sparql", new Post {
			body = "query=SELECT * {?s ?p ?o} LIMIT 10",
		})
		.Then(res => this.LogMessage ("Success", JsonUtility.ToJson(res, true)))
		.Catch(err => this.LogMessage ("Error", err.Message));
	}

    public void TestValueEmotion()
    {
        RequestHelper rh = new RequestHelper
        {
            Uri = "http://150.146.211.34:8080/predict",
            Method = "GET",
            Headers = new Dictionary<string, string> {
          { "Accept", "application/json" }
        },
            Params = new Dictionary<string, string> {
          { "txt", "I feel surprise" }
        }
        };

        RestClient.Request(rh)
            .Then(res => this.Log("Success", res))
            .Catch(err => this.LogMessage("Error", err.Message));
    }


  public void GETLDH(){
    RequestHelper rh = new RequestHelper { 
        Uri = "https://api2.mksmart.org/object/a6ad7a45-3d69-44c2-8f57-e0830e748f0d/60c095321262e65eec197529",
        Method = "GET",
        Headers = new Dictionary<string, string> {
          { "Accept", "application/json" },
          { "Authorization", "Basic MGY5ZmU5NTMtZTQ5OS00NDI5LWI3NGMtNTZhNGZhOWZkYTI5OjBmOWZlOTUzLWU0OTktNDQyOS1iNzRjLTU2YTRmYTlmZGEyOQ==" }
        }
      };
      
    RestClient.Request(rh)
        .Then(res => this.Log ("Success", res))
        .Catch(err => this.LogMessage ("Error", err.Message));
  }


    public void Postr(){
    RequestHelper rh = new RequestHelper { 
        Uri = "https://dbpedia.org/sparql",
        Method = "POST",
        Headers = new Dictionary<string, string> {
          { "Accept", "application/json" }
        },
        Params = new Dictionary<string, string> {
          { "query", "SELECT * {?s ?p ?o} LIMIT 10" }
        }
      };
      
    RestClient.Request(rh)
        .Then(res => this.Log ("Success", res))
        .Catch(err => this.LogMessage ("Error", err.Message));
  }


	private void LogMessage(string title, string message) {
    Debug.Log(title);
		Debug.Log(message);
    

	}

  private void Log(string title, ResponseHelper o) {
    Debug.Log(title);
    Debug.Log(o.Text);
    string js = JsonUtility.ToJson(o, true);
    Debug.Log(js);
    var obj = JSON.Parse(o.Text);

    bool lastword = obj["Emotion"].ToString().Contains("surprise");
    Debug.Log(" Lastword is:" + lastword+"-");

    Debug.Log(obj["head"]);
    Debug.Log(obj["head"]["vars"]);
    Debug.Log(obj["head"]["vars"][0]);

    var bindings = obj["results"]["bindings"];

    for (int i = 0; i< bindings.Count; i++)  {//or res.Count()

      Debug.Log(bindings[i]);
      Debug.Log(bindings[i]["p"]["value"]);
    }

    //var jsonObject = new JsonObject(o.Text);

    //Debug.Log(jsonObject["head"]["vars"][0]);

    //Debug.Log(o["head"]);

	}

  

}
