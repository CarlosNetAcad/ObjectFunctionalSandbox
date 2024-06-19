using ObjectFunctionalSandbox.Patterns;

var result = ResultPattern.Divide( 10,0 );

if( result.IsSuccess )
    Console.WriteLine( result.Value );
else
    Console.WriteLine( result.Error );