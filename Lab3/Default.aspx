<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Lab3._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Errorlabel" runat="server"></asp:Label>
    <br />
    <h1>Login</h1>
    <label>Username</label>
    <asp:TextBox ID="Username" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ControlToValidate="Username" Display="Static" ErrorMessage="Username is required." ID="validateUsername" runat="Server" ForeColor="Red" />
    <br />
    <br />
    <label>Password</label>
    <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ControlToValidate="Password" Display="Static" ErrorMessage="Password is required." ID="validatePassword" runat="Server" ForeColor="Red" />
    <br />
    <br />
    <asp:Button ID="btnLogin" OnClick="btnLogin_Click" runat="server" Text="LOGIN" />
    <br />
    <br />
    <div class="slideshow-container">
        <div class="mySlides fade">
            <div class="numbertext">1 / 4</div>
            <img src="./images/Picture1.jpg" style="width: 100%">
            <div class="text">Share your excitement in the field of computer information systems and cultivate the interests of young people in future business/technology related careers</div>
        </div>

        <div class="mySlides fade">
            <div class="numbertext">2 / 4</div>
            <img src="./images/Picture2.jpg" style="width: 100%">
            <div class="text">You will learn to develop advanced competencies and diagnostic skills to correct software problems</div>
        </div>

        <div class="mySlides fade">
            <div class="numbertext">3 / 4</div>
            <img src="./images/Picture3.jpg" style="width: 100%">
            <div class="text">Learning, fun and interative</div>
        </div>

        <div class="mySlides fade">
            <div class="numbertext">4 / 4</div>
            <img src="./images/Picture4.jpg" style="width: 100%">
            <div class="text">Get hands on experience</div>
        </div>

        <a class="prev" onclick="plusSlides(-1)">&#10094;</a>
        <a class="next" onclick="plusSlides(1)">&#10095;</a>
    </div>
    <br />
    <br />
    <div id="accordion-div">
        <h3>FAQ</h3>
        <button type="button" class="accordion">Who signs up the students?</button>
        <div class="panel">
            <p class="answer">Teachers/Admins </p>
        </div>

        <button type="button" class="accordion">What does Cyberday consist of?</button>
        <div class="panel">
            <p class="answer">Computer programming activities, Team building exercises, and Lunch</p>
        </div>

        <button type="button" class="accordion">What age is this event catered for?</button>
        <div class="panel">
            <p class="answer">Middle Schoolers</p>
        </div>
    </div>
    <script>
        var slideIndex = 1;
        showSlides(slideIndex);

        function plusSlides(n) {
            showSlides(slideIndex += n);
        }

        function currentSlide(n) {
            showSlides(slideIndex = n);
        }

        function showSlides(n) {
            var i;
            var slides = document.getElementsByClassName("mySlides");
            var dots = document.getElementsByClassName("dot");
            if (n > slides.length) { slideIndex = 1 }
            if (n < 1) { slideIndex = slides.length }
            for (i = 0; i < slides.length; i++) {
                slides[i].style.display = "none";
            }
            for (i = 0; i < dots.length; i++) {
                dots[i].className = dots[i].className.replace(" active", "");
            }
            slides[slideIndex - 1].style.display = "block";
            dots[slideIndex - 1].className += " active";
        }

        var acc = document.getElementsByClassName("accordion");
        var i;

        for (i = 0; i < acc.length; i++) {
            acc[i].addEventListener("click", function () {
                /* Toggle between adding and removing the "active" class,
                to highlight the button that controls the panel */
                this.classList.toggle("active");

                /* Toggle between hiding and showing the active panel */
                var panel = this.nextElementSibling;
                if (panel.style.display === "block") {
                    panel.style.display = "none";
                } else {
                    panel.style.display = "block";
                }
            });
        }

        var acc = document.getElementsByClassName("accordion");
        var b;

        for (b = 0; b < acc.length; b++) {
            acc[b].addEventListener("click", function () {
                /* Toggle between adding and removing the "active" class,
                to highlight the button that controls the panel */
                this.classList.toggle("active");

                /* Toggle between hiding and showing the active panel */
                var panel = this.nextElementSibling;
                if (panel.style.display === "block") {
                    panel.style.display = "none";
                } else {
                    panel.style.display = "block";
                }
            });
    </script>
    <style>
        * {
            box-sizing: border-box
        }

        body {
            font-family: Verdana, sans-serif;
            margin: 0
        }

        .mySlides {
            display: none
        }

        img {
            vertical-align: middle;
        }

        /* Slideshow container */
        .slideshow-container {
            max-width: 1000px;
            position: relative;
            margin-top: 50px !important;
            margin: auto;
        }

        /* Next & previous buttons */
        .prev, .next {
            cursor: pointer;
            position: absolute;
            top: 50%;
            width: auto;
            padding: 16px;
            margin-top: -22px;
            color: white;
            font-weight: bold;
            font-size: 18px;
            transition: 0.6s ease;
            border-radius: 0 3px 3px 0;
            user-select: none;
        }

        /* Position the "next button" to the right */
        .next {
            right: 0;
            border-radius: 3px 0 0 3px;
        }

            /* On hover, add a black background color with a little bit see-through */
            .prev:hover, .next:hover {
                background-color: rgba(0,0,0,0.8);
            }

        /* Caption text */
        .text {
            color: #f2f2f2;
            background-color: black;
            font-size: 15px;
            padding: 8px 12px;
            position: absolute;
            bottom: 8px;
            width: 100%;
            text-align: center;
        }

        /* Number text (1/3 etc) */
        .numbertext {
            color: #f2f2f2;
            font-size: 12px;
            padding: 8px 12px;
            position: absolute;
            top: 0;
        }

        /* The dots/bullets/indicators */
        .dot {
            cursor: pointer;
            height: 15px;
            width: 15px;
            margin: 0 2px;
            background-color: #bbb;
            border-radius: 50%;
            display: inline-block;
            transition: background-color 0.6s ease;
        }

            .active, .dot:hover {
                background-color: #717171;
            }

        /* Fading animation */
        .fade {
            -webkit-animation-name: fade;
            -webkit-animation-duration: 1.5s;
            animation-name: fade;
            animation-duration: 1.5s;
            animation-fill-mode: forwards;
        }

        @-webkit-keyframes fade {
            from {
                opacity: .4
            }

            to {
                opacity: 1
            }
        }

        @keyframes fade {
            from {
                opacity: .4
            }

            to {
                opacity: 1
            }
        }
        /* Style the buttons that are used to open and close the accordion panel */
        .accordion {
            background-color: #eee;
            color: #444;
            cursor: pointer;
            padding: 18px;
            width: 100%;
            text-align: left;
            border: none;
            outline: none;
            transition: 0.4s;
        }

            /* Add a background color to the button if it is clicked on (add the .active class with JS), and when you move the mouse over it (hover) */
            .active, .accordion:hover {
                background-color: #ccc;
            }

        /* Style the accordion panel. Note: hidden by default */
        .panel {
            padding: 0 18px;
            background-color: white;
            display: none;
            overflow: hidden;
        }

        .answer {
            margin: 20px;
            height: 100%;
        }
    </style>
</asp:Content>

