namespace DesignPatterns.Structural.Facade;

public class AudioCodec { public string Extract() => "AudioStream"; }
public class VideoCodec { public string Decode() => "VideoStream"; }

public class VideoConverterFacade {
    public string ConvertMp4ToAvi(string filename) {
        var a = new AudioCodec().Extract();
        var v = new VideoCodec().Decode();
        return $"{filename}_converted_{a}_{v}";
    }
}
