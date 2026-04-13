using System;
using System.Collections.Generic;

namespace CyberAware.Classes
{
    public class ResponseHandler
    {
        private Dictionary<string, string> responses;

        public ResponseHandler()
        {
            InitializeResponses();
        }

        private void InitializeResponses()
        {
            responses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                // Greetings
                { "how are you", "I'm functioning well, thank you for asking! Ready to help you stay secure online." },
                { "hello", "Hello! I'm CyberAware, your security assistant. How can I help you today?" },
                { "hi", "Hi there! Ask me anything about cybersecurity and staying safe online." },
                
                // Purpose
                { "what is your purpose", "My purpose is to educate and protect South Africans from cyber threats like phishing, SIM swap scams, and identity theft." },
                { "what can you do", "I can teach you about password safety, phishing detection, 2FA, safe browsing, and South African cyber threats." },
                
                // Password safety
                { "password", "Use strong passwords with 12+ characters, mix of letters, numbers, and symbols. Never reuse passwords across sites!" },
                { "password safety", "Create unique passwords for each account, use a password manager, and enable 2FA whenever possible." },
                
                // Phishing
                { "phishing", "Phishing is when scammers pretend to be legitimate companies to steal your info. Never click suspicious links or share personal data via email!" },
                { "email scam", "Check sender addresses carefully, look for spelling errors, and never download attachments from unknown senders." },
                
                // 2FA
                { "2fa", "Two-Factor Authentication adds an extra layer of security. Even if someone steals your password, they can't access your account without the second factor." },
                { "two factor", "Use authenticator apps like Google Authenticator or Microsoft Authenticator instead of SMS when possible." },
                
                // South Africa specific
                { "sim swap", "SIM swap scam is when criminals trick your mobile provider into transferring your number. Contact your bank immediately if you lose signal!" },
                { "vishing", "Vishing is voice phishing - scammers call pretending to be from your bank. Never share OTPs or PINs over the phone!" },
                { "south africa", "In South Africa, be aware of SIM swap scams, vishing calls, and WhatsApp fraud. Always verify before trusting." },
                
                // Safe browsing
                { "safe browsing", "Look for 'https://' and padlock icon in address bar. Avoid public WiFi for banking, and keep your browser updated." },
                { "https", "HTTPS encrypts data between you and websites. Always check for it before entering passwords or payment info." },
                
                // Social engineering
                { "social engineering", "Social engineering manipulates people into giving up confidential info. Never share passwords or OTPs with anyone!" },
                { "scam", "Scammers create urgency and fear. Take a moment to verify independently before taking action." },
                
                // General help
                { "what can i ask", "You can ask me about: passwords, phishing, 2FA, safe browsing, social engineering, SIM swap scams, and vishing." },
                { "help", "I can help with cybersecurity topics. Try asking about passwords, phishing, 2FA, or South African cyber threats!" },
                
                // Default fallback
                { "default", "That's a great question about cybersecurity! Could you rephrase it? I specialize in topics like passwords, phishing, 2FA, and safe browsing." }
            };
        }

        public string GetResponse(string userInput, string userName)
        {
            if (string.IsNullOrWhiteSpace(userInput))
                return "I didn't catch that. Could you please repeat?";

            
            if (userInput.Contains("my name") || userInput.Contains($"i am {userName?.ToLower()}"))
            {
                return $"Nice to meet you, {userName}! How can I help you with cybersecurity today?";
            }

            
            if (userInput.Contains("thank") || userInput.Contains("thanks"))
            {
                return $"You're welcome, {userName}! Stay safe online!";
            }

            
            if (userInput.Contains("who are you"))
            {
                return "I'm CyberAware, your AI-powered cybersecurity assistant created to help South Africans stay safe from online threats!";
            }

            
            foreach (var kvp in responses)
            {
                if (userInput.Contains(kvp.Key.ToLower()))
                {
                    return kvp.Value;
                }
            }

            
            return responses["default"];
        }

        public void AddCustomResponse(string keyword, string response)
        {
            if (!responses.ContainsKey(keyword))
            {
                responses.Add(keyword, response);
            }
        }
    }
}