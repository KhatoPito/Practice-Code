# README

Round 2) With Two Dev Leads - 30 mins technical and 30 mins coding 

1) what are the benefits of hangfire
2) In what situation you would use Azure Function, Azure Servce and Azure Kubernatives 

3) in microservice architecture, lets say Service A communicates to Service B 
How do we keep monitoring or track of the issue lets say when Service B is down or doesn't reponse to Service Request from A

4)  Lets say if something goes wrong with rabbitMQ, queues are piling up or jobs are not picked up, what setup can we have such that, those issues are notified or alerted ASAP 



Coding 

find if two strings are anagrams or not


Round 1) With Director >> 

## Why Do You Want to Leave Neogov?
At Neogov, I've had the privilege of leading the development and launch of impactful SaaS solutions. While I'm grateful for the experience, I'm now seeking an opportunity to leverage my full technical expertise on a larger scale. Loan Depot's focus on innovation within the mortgage industry is particularly exciting, and I believe my leadership and technical skills align well with the challenges and opportunities you present.

## Why Do You Want to Join Loan Depot as Lead Developer?
Loan Depot's dedication to fostering a superior customer experience through cutting-edge technology deeply resonates with me. My proven track record of leading cross-functional teams and architecting enterprise applications directly translates to the requirements of the Lead Developer role. I'm confident that my skills and experience can significantly contribute to Loan Depot's continued success and advancement in the mortgage industry.

While I value the experience of team management, my long-term career goal is to focus on technical leadership within a specific domain. This Dev Lead role is a perfect stepping stone towards that goal, allowing me to hone my technical skills while still leading and mentoring developers.

This Dev Lead position offers the perfect blend of technical leadership and individual contribution. I can still leverage my leadership skills through mentoring and code reviews, while also diving back into the technical aspects of software development that I truly enjoy.

## How Would You Design This Feature?

### Scenario:
- **User A** opens **Dashboard X**, which has an update for **Money Spent** to be `$20`.
- **User B** opens the same **Dashboard X** of the same application and updates **Money Spent** to be `$20 + $5`.

### Requirement:
- Ensure that **User A** sees `$25` and not `$20` after **User B**'s update.

### Design:
1. **Real-Time Data Synchronization**: Implement WebSockets to ensure real-time data synchronization between users viewing the same dashboard.
2. **Optimistic Locking**: Use optimistic locking to handle concurrent updates to the dashboard data. When **User B** updates the **Money Spent** value, the backend should check the current value before applying the update.
3. **Event Broadcasting**: When **User B** updates the **Money Spent** value, broadcast this event to all other users viewing the same dashboard using a message broker (e.g., RabbitMQ or Kafka).
4. **Client-Side Update**: On receiving the broadcasted event, the client (User A's dashboard) updates the **Money Spent** value to `$25`.

## How Would You Design a System to Send Email Notifications Upon User Actions?

### Requirement:
- Do not send an email for every action.
- Wait for 15 minutes and, during that time, if the user takes **Action P** & **Action M**, then send an email.

### Design:
1. **Action Logging**: Log user actions in a database with timestamps.
2. **Batch Processing**: Implement a batch processing job that runs every 15 minutes to check for specific user actions.
3. **Conditional Email Sending**: The batch job checks if both **Action P** and **Action M** occurred within the same 15-minute window. If so, it triggers an email notification.
4. **Notification Service**: Create a notification service responsible for sending emails based on the conditions evaluated by the batch job.
5. **Database Structure**: 
    - **UserActions** Table: Columns for `UserId`, `ActionType`, and `Timestamp`.
    - **EmailQueue** Table: Columns for `UserId`, `EmailType`, and `ScheduledTime`.
6. **Sample Workflow**:
    - User performs **Action P** at `T0`.
    - **Action P** is logged in the `UserActions` table.
    - User performs **Action M** at `T0 + 10 minutes`.
    - **Action M** is logged in the `UserActions` table.
    - Batch job runs at `T0 + 15 minutes`, detects both actions for the user, and queues an email.
    - Notification service processes the email queue and sends the email.

