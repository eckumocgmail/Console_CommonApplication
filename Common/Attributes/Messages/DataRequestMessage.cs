using Newtonsoft.Json;

using System;
using System.Collections.Generic;


/// <summary>
/// Модель "Удалённый вызов процедуры"
/// </summary>
[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public class DataRequestMessage: EventArgs
{


    /// <summary>
    /// Ключ доступа клиента
    /// </summary>
    [JsonProperty("token")]
    public string AccessToken { get; set; } = "";


    /// <summary>
    /// Идентификатор сообщения
    /// </summary>
    [JsonProperty("mid")]
    public string TraceId { get; set; } = "";

    /// <summary>
    /// Идентификатор сообщения
    /// </summary>
    [JsonProperty("pk")]
    public string SerialKey { get; set; } = "";


    /// <summary>
    /// Имя процедуры
    /// </summary>
    [JsonProperty("request.path")]
    public string ActionName { get; set; } = "";


    /// <summary>
    /// Параметры выполнения
    /// </summary>
    [JsonProperty("request.pars")]
    public Dictionary<string, object> ParametersMap { get; set; } = new Dictionary<string, object>();


    public byte[] MessageBody { get; set; } = new byte[0];
    public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();



    
}