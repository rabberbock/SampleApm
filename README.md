#Sample Project

Comment in 
```
//if (!Agent.IsConfigured)
//{
//    Agent.Setup(sp.GetRequiredService<AgentComponents>());
//    Agent.Subscribe(new HttpDiagnosticsSubscriber(),
//                    new EfCoreDiagnosticsSubscriber(),
//                    new SqlClientDiagnosticSubscriber());
//}
```

to see that now trace is collected.