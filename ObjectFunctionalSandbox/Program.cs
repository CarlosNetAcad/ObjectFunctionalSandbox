using ObjectFunctionalSandbox.Patterns;

var result = ResultPattern.ReadFile( "test.text" );

if( result.IsSuccess )
    Console.WriteLine( result.Value );
else
    Console.WriteLine( result.Error );