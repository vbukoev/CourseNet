## Overview 👨🏻‍💻

"CourseNet" is a web application with educational and demonstrative purposes. It mimics (in a much smaller scale) systems used for management of online courses and enrolling in them. You can enroll in to different courses, lectures, you can get a huge amount of materials, become students or even instructors of the courses.

   ## Technologies used ⚙️
<ul>
  <li>.NET Core 6.0</li>
  <li>ASP.NET Core</li>
  <li>Entity Framework Core</li>
  <li>HTML, CSS, Bootstrap</li>
  <li>MS SQL Server</li>
  <li>NUnit</li>
  <li>Moq</li>
  <li>JS</li>
</ul>

## Users 🧑‍🤝‍🧑
There are 4 types of users with different access to the application's functionality:

<ul>
  <li>
    <b>Guest</b> - logged off user. Guests can only view available courses. 
  </li>
  <li>
    <b>Student</b> - This is the user who can enroll the courses which were created by the instructor.
  </li>
  <li>
    <b>Instructor</b> - This is the user who creates the courses and which courses can be enrolled by the students of the system
  </li>
  <li>
    <b>Administrator</b> - The administrator can alter the global settings of the application and delete courses, lectures, materials, reviews.
  </li>
</ul>

## Test credentials
You can test the application with pre-seeded data using the following credentials:

#### Student
Username: test@students.com </br>
Password: 123456

#### Instructor
Username: futureInstructor@instructors.com </br>
Password: 123456

#### Administrator
Username: admin@coursenet.bg</br>
Password: 123456

## Database diagram

![database-diagram](https://github.com/vbukoev/CourseNet/assets/105813259/90122816-5ccb-45fc-bd4f-4472e04819aa)

# Functionality

## Table of contents
<ul>
  <li>
    <a href="#user-registration">User registration</a>
  </li>
  <li>
    <a href="#home-page">Home page</a>
  </li>
  <li>
    <a href="#admin-home-page">Administration home page</a>
  </li>
  <li>
    <a href="#all-courses">All courses</a>
  </li>
  <li>
    <a href="#details-section-of-the-course">Details section of the course</a>
  </li>
  <li>
    <a href="#edit-section-of-the-course">Edit section of the course</a>
  </li>
  <li>
    <a href="#delete-section-of-the-course">Delete section of the course</a>
  </li>
    <li>
    <a href="#my-courses">My courses</a>
  </li>
    <li>
    <a href="#become-instructor-page">Become instructor page</a>
  </li>
  <li>
    <a href="#error-page">Error page</a>
  </li>
</ul>

## User registration
On the registration page, you can create a new user profile as a student. To become an instructor first you have to be registered as a student and after that in the application there is a button where you can become instructor.
![user-registration](https://github.com/vbukoev/CourseNet/assets/105813259/2e047b95-3990-4727-aeb5-51d0492509f7)

## Home page
On the home page, Guests can view the all of the available courses but they can not enroll into them or become instructors. To do this, they have to be registered users.
![home-page](https://github.com/vbukoev/CourseNet/assets/105813259/d90d803a-457d-4362-9c83-84ce19112e8b)

## Admin home page
This is the admin home page, where administators can see all of the content available in the application. They can test the application and see statistics for the app. There they can find all of the courses, they can add a course, they can see all of the courses which they have created. They can also see the enrolled courses and all of the users in the app.
![admin-home-page](https://github.com/vbukoev/CourseNet/assets/105813259/25699a04-7dfc-4afe-92b8-6cc0b30a685e)

## All courses
Here you can see all of the available courses in the application. If you are an admin or the instructor, who created the course, you can either choose to see details of the course, edit it or to delete it. 
![all-courses](https://github.com/vbukoev/CourseNet/assets/105813259/7eb25df1-3392-442b-8071-8a5aa9713705)

## Details section of the course
Here you can see the details of the course - description, price, category, difficulty and the end date of course. Also here is the option to see all the lectures and reviews of the course. Another useful information displayed here is the information about the creator(the instructor) of the course - his email and phone number.
![course-details](https://github.com/vbukoev/CourseNet/assets/105813259/8e512be8-b654-49b8-8bbf-38c273e6fb30)

## Edit section of the course
Here you can edit the course. You can change its description, price, category, difficulty and the end date of course and after all of the changes you can submit them to the application.  
![course-edit](https://github.com/vbukoev/CourseNet/assets/105813259/0311df60-4c25-4be6-9b13-6a59aa9b3bef)

## Delete section of the course
Below you can see the delete page when you try to delete a course. To do it you have to have either administrator role in the application or you have to be the instructor who created the course.
![course-delete](https://github.com/vbukoev/CourseNet/assets/105813259/16932c1b-6bfd-4e86-83bd-d7004b75bcbc)

## My courses
The page where you can see the courses which you enrolled.
![courses-mine](https://github.com/vbukoev/CourseNet/assets/105813259/dd9fde5d-63fd-465d-a5f7-7db254f4da3f)

## Become instructor page
This page is the place where you can become an instructor.
![instructor-become](https://github.com/vbukoev/CourseNet/assets/105813259/5c69ae36-ded0-43bb-9ea5-7f50d94f2db2)

## All categories
The page where all categories are shown. There are buttons for the details, delete button, edit button.
![all-categories](https://github.com/vbukoev/CourseNet/assets/105813259/f76369db-1ef2-4461-938f-9777885da3ca)

## Create category page
You can create a category first if you have the permissions to do it. It can be done by only submitting the category name.
![create-category-page](https://github.com/vbukoev/CourseNet/assets/105813259/dda8b9d8-34b6-48cf-abed-358f885a6b62)

## Details of the category
The page where the name of the category is shown.
![details-of-the-category](https://github.com/vbukoev/CourseNet/assets/105813259/42b695ee-a7dd-4325-9c26-aa041db79504)

## Edit category page
This is the page where you can change the category name.
![edit-category-page](https://github.com/vbukoev/CourseNet/assets/105813259/37cb3e6d-b25d-492d-a622-851a620dda4b)

## Delete category page
The page where you are questioned if you are sure you want to delete the category. If you delete the category, you are going to delete all of the courses which are from this category. 
![delete-category-page](https://github.com/vbukoev/CourseNet/assets/105813259/35fc3eea-9849-4c20-89d1-a736a165663f)

## All lectures for course
This is the page where you can see all of the lectures which are related to the course you want to check. There are buttons for deleting the lecture if you have the permissions, adding materials to the lecture, or to see the current materials available.
![all-lectures-for-course](https://github.com/vbukoev/CourseNet/assets/105813259/63ec8fb2-1588-47b0-ae00-6fb9c445b688)

## Create lectures
If the user wants to create lecture, first of all the user has to have the permissions. After that, he/she has to add the title of the lecture and its description. After all the last thing is to hit the submit button.  
![create-lectures](https://github.com/vbukoev/CourseNet/assets/105813259/2802d4d1-c7f3-45b1-ad89-010710cc1a2d)

## Delete lecture
The delete page of the lecture shows its name and questions its instructor(creator)/administrator if he/she is sure.
![delete-lecture](https://github.com/vbukoev/CourseNet/assets/105813259/0e139ee5-8863-4046-b868-bcd7bcd35ab8)

## All materials for lecture
The page where all materials for the lectures are shown.
![all-materials-page](https://github.com/vbukoev/CourseNet/assets/105813259/6f0e75a2-247b-40c6-81eb-14ad2b199b47)

## Edit the material
There is an option to change the name of the material and to change its description.
![edit-material](https://github.com/vbukoev/CourseNet/assets/105813259/36839cb1-cec3-4c18-9b55-779637920b7c)

## Delete material
The page where you are questioned if you are sure you want to delete the material. You can delete it if you have the needed permissions.
![delete-material](https://github.com/vbukoev/CourseNet/assets/105813259/05dd7aad-008b-4f7b-8381-9312821dc8ea)

## All reviews for the course
All reviews shown in this page.
![all-reviews-for-the-course](https://github.com/vbukoev/CourseNet/assets/105813259/cd0cd960-169d-482a-87d5-a6bfebf21990)

## Create review for the course
The page where you can add review to the course by adding rating for the course(from 1 to 10) and comment to the review.
![create-review-for-the-course](https://github.com/vbukoev/CourseNet/assets/105813259/c01a430f-c6c0-4d54-9b10-07576b44d79e)
