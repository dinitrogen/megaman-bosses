# Megaman Bosses
A simple API to serve boss information from the Megaman/Rockman series of video games. Built with ASP.NET and C# and hosted with Fly.io.

## Production host
[https://megaman-bosses-api.fly.dev/](https://megaman-bosses-api.fly.dev/)

## APIs

### `GET /bosses`
Returns an array of all robot masters:
```json
[
  {
    "id": "009",
    "name": "Metal Man",
    "weapon": "Metal Blade",
    "avatar": "http://vignette1.wikia.nocookie.net/megaman/images/6/69/Metalmugshot.png",
    ...
  },
  {
    "id": "010",
    "name": "Air Man",
    "weapon": "Air Blade",
    "avatar": "http://vignette1.wikia.nocookie.net/megaman/images/a/af/Airmugshot.png",
    ...
  },
  {
    "id": "011",
    "name": "Bubble Man",
    "weapon": "Bubble Lead",
    "avatar": "http://vignette4.wikia.nocookie.net/megaman/images/5/53/Bubblemugshot.png",
    ...
  },
  ...
]
```

### `GET /bosses/<id>`
Returns a robot master by its `<id>` or Serial No. Leading `0` gets truncated. (e.g. `'014'` - becomes -> `14`)
```json
{
  "id": "014",
  "name": "Flash Man",
  "weapon": "Time Stopper",
  "avatar": "http://vignette2.wikia.nocookie.net/megaman/images/3/39/Flashmugshot.png",
  ...
}
    
```