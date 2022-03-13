public class SendMessageBench : BenchmarkBase {

    protected override void Init() {
        BenchmarkName = "Send Message";
        
        Benchmarks.Add(new BenchmarkData("Send Message", () => { SendMessage(nameof(SendMessageHelper.CallThisFunction), 69); }));
        Benchmarks.Add(new BenchmarkData("Get Component", () => {
            var caller = GetComponent<SendMessageHelper>();
            caller.CallThisFunction(69);
        }));
    }
}