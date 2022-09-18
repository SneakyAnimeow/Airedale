function Login(){
    return(
        <>
            <div id="login-form">
                <h1>Login</h1>
                <form action="/api/Login" method="POST">
                    <label htmlFor="username">Username</label>
                    <input type="text" id="username" name="username" />
                    <label htmlFor="password">Password</label>
                    <input type="password" id="password" name="password" />
                    <button type="submit">Login</button>
                </form>
            </div>
        </>
    )
}

export default Login;