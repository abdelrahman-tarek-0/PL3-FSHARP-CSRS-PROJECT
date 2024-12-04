open System
open System.Drawing
open System.Windows.Forms

// Define the LoginForm class
type LoginForm() as this =
    inherit Form(Text = "Login Form", Width = 400, Height = 250)

    // Define UI components with centered alignment and bold text
    let lblUsername =
        new Label(
            Text = "Username:",
            Width = 200,
            Height = 30,
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Arial", 12.0F, FontStyle.Bold),
            Top = 50,
            Left = 100
        )

    let txtUsername =
        new TextBox(Width = 200, Height = 30, Font = new Font("Arial", 12.0F, FontStyle.Regular), Top = 90, Left = 100)

    let btnLogin =
        new Button(
            Text = "Login",
            Width = 100,
            Height = 40,
            Font = new Font("Arial", 12.0F, FontStyle.Bold),
            Top = 140,
            Left = 150
        )

    // Variable to store the logged-in username
    let mutable loggedInUser = ""

    // Define the login logic
    let loginAction _ =
        if String.IsNullOrWhiteSpace(txtUsername.Text) then
            MessageBox.Show("Please enter a username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            |> ignore
        else
            loggedInUser <- txtUsername.Text // Save the username

            MessageBox.Show($"Welcome, {loggedInUser}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            |> ignore

            this.Close() // Close the login form

    do
        // Add components to the form
        this.Controls.AddRange([| lblUsername; txtUsername; btnLogin |])

        // Attach event handler
        btnLogin.Click.Add(loginAction)
   // Get date and time to use it in booking
   let DateAandtTime () = 
        let now = System.DateTime.Now
        now.ToString("yyyy-MM-dd HH:mm:ss")

// Run the LoginForm
[<EntryPoint>]
let main _ =
    Application.EnableVisualStyles()
    let loginForm = new LoginForm()
    Application.Run(loginForm)
    0
