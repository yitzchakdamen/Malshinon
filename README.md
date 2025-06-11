# Malshinon

**Malshinon** הוא פרויקט לניהול, ניתוח ודיווח מודיעיני, הכולל מערכת לניהול אנשים, סטטוסים, התראות, דוחות, וממשק משתמש קונסול.

---

## תוכן עניינים

- [סקירה כללית](#סקירה-כללית)
- [מבנה הפרויקט](#מבנה-הפרויקט)
- [דרישות מערכת](#דרישות-מערכת)
- [התקנה והרצה](#התקנה-והרצה)
- [תיעוד רכיבים עיקריים](#תיעוד-רכיבים-עיקריים)
- [דוגמה לזרימת עבודה](#דוגמה-לזרימת-עבודה)
- [תרומה](#תרומה)
- [רישיון](#רישיון)

---

## סקירה כללית

Malshinon נועד לאפשר שליחת דיווחים מודיעיניים בין אנשים, ניהול סטטוסים ועדכון נתונים בזמן אמת, כולל ניתוח פעילות חשודה. המערכת בנויה בשכבות: גישה לנתונים (DAL), לוגיקת ניהול, טיפול, ו-UI קונסול.

---

## מבנה הפרויקט

```
Malshinon/
├── Create/                # יצירת מופעים של אובייקטים (Person, IntelReport, Alert וכו')
├── DAL/                   # שכבת גישה לנתונים (Data Access Layer)
├── Database/              # ניהול חיבור למסד הנתונים
├── Handling/              # לוגיקת טיפול (אנליזה, הודעות, תפריטים)
│   └── MessageHandling.cs # טיפול בשליחת הודעות ועדכון סטטוסים
├── Management/            # ניהול ישויות (אנשים, התראות, דוחות)
├── Menu/                  # תפריטים וממשק משתמש
├── Models/                # מחלקות מודל (Person, Alert, IntelReport וכו')
├── Program.cs             # נקודת הכניסה הראשית
├── Malshinon.csproj       # קובץ פרויקט
└── GenerateTables.sql     # סקריפט יצירת טבלאות למסד הנתונים
```

---

## דרישות מערכת

- .NET 6 ומעלה
- MySQL (כולל חיבור פעיל)
- חבילת `MySql.Data`

---

## התקנה והרצה

1. **שכפול הפרויקט:**
   ```sh
   git clone <repository-url>
   cd Malshinon
   ```

2. **התקנת תלויות:**
   ```sh
   dotnet restore
   ```

3. **הגדרת מסד נתונים:**
   - הרץ את [GenerateTables.sql](GenerateTables.sql) ליצירת הטבלאות במסד הנתונים שלך.
   - עדכן את פרטי החיבור בקובץ המתאים (לרוב ב-`Database/Database.cs`).

4. **הרצת הפרויקט:**
   ```sh
   dotnet run
   ```

---

## תיעוד רכיבים עיקריים

### Handling/MessageHandling.cs

מחלקה זו אחראית על שליחת הודעות ועדכון סטטוסים בין אנשים.  
**דוגמה לפעולה עיקרית:**

```csharp
public void SendMessage(
    string? firstNamePerson = null,
    string? lastNamePerson = null,
    string? secretCodePerson = null,
    string? firstNametarget = null,
    string? lastNametarget = null,
    string? secretCodetarget = null,
    string? messageText = null
)
{
    var peopleIds = People(firstNamePerson, lastNamePerson, secretCodePerson, firstNametarget, lastNametarget, secretCodetarget);
    if (peopleIds == null || messageText == null)
        return;

    Messages(peopleIds.Value.personID, peopleIds.Value.targetId, messageText);
    UpdateStatus(peopleIds.Value.personID, peopleIds.Value.targetId);
    analysisHandling.Analysis(peopleIds.Value.personID, peopleIds.Value.targetId, DateTime.Now);
}
```

- **People**: מאתר מזהי אנשים לפי פרטים.
- **Messages**: מוסיף דיווח מודיעיני חדש.
- **UpdateStatus**: מעדכן סטטוס של השולח והיעד.
- **Analysis**: מבצע ניתוח פעילות.

### DAL/

שכבת הגישה לנתונים, אחראית על שליפות, עדכונים, והוספת נתונים למסד.

### Management/

ניהול ישויות, סטטוסים, התראות, דוחות.

### Menu/

ממשק משתמש קונסול, תפריטים, הדפסות.

---

## דוגמה לזרימת עבודה

1. **שליחת הודעה מודיעינית:**
   - המשתמש מזין פרטי שולח, יעד, וטקסט.
   - המערכת מאתרת את האנשים, מוסיפה דיווח, מעדכנת סטטוסים, ומבצעת ניתוח.

2. **צפייה בדוחות/התראות:**
   - דרך התפריט הראשי, ניתן לצפות בדוחות, התראות, סטטוסים ועוד.

---

## תרומה

תרומות יתקבלו בברכה!  
יש לפתוח Pull Request או Issue.

---

## רישיון

הפרויקט מופץ תחת רישיון MIT.

---