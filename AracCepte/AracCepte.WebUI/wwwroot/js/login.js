document.getElementById('loginForm').addEventListener('submit', async function (event) {
    event.preventDefault();

    const email = document.getElementById('email').value;
    const password = document.getElementById('password').vaLue;

    const response = await fetch("https://localhost:7133/api/auth/login", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            email: email,
            password: password
        })
    });

    if (response.ok) {
        const data = await response.json();
        const token = data.token;
        console.log('JWT Token', token);
        localStorage.setItem('token', token);
        allert('Giris Basarili');
        window.location.href = '/HomePage'
    }
    else {
        allert('Giris Basarisiz');
    }
}